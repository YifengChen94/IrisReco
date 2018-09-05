import tensorflow as tf
import os
import numpy as np
import iris_input
import re
import iris_tfrecord

TOWER_NAME = 'tower'
batch_size = iris_input.BATCH_SIZE
train_samples_per_epoch=iris_input.train_samples_per_epoch
test_samples_per_epoch=iris_input.test_samples_per_epoch
Class = iris_tfrecord.tfrecords(path=iris_tfrecord.Path).generate_tfrecords()
moving_average_decay = 0.9999     # The decay to use for the moving average.
num_epochs_per_decay =50# 衰减呈阶梯函数，控制衰减周期（阶梯宽度）
learning_rate_decay_factor = 0.2  # 学习率衰减因子
initial_learning_rate = 0.1      # 初始学习速率

def _activation_summary(x):
  """Helper to create summaries for activations.

  Creates a summary that provides a histogram of activations.
  Creates a summary that measure the sparsity of activations.

  Args:
    x: Tensor
  Returns:
    nothing
  """
  # Remove 'tower_[0-9]/' from the name in case this is a multi-GPU training
  # session. This helps the clarity of presentation on tensorboard.
  tensor_name = re.sub('%s_[0-9]*/' % TOWER_NAME, '', x.op.name)
  tf.summary.histogram(tensor_name + '/activations', x)
  tf.summary.scalar(tensor_name + '/sparsity', tf.nn.zero_fraction(x))

def variable_on_cpu(name, shape, dtype, initializer):
   # with tf.device("/cpu:0"):  # 一个 context manager,用于为新的op指定要使用的硬件
    return tf.get_variable(name=name,
                           shape=shape,
                           initializer=initializer,
                           dtype=dtype)


def variable_on_cpu_with_collection(name, shape, dtype, wd):
    #with tf.device("/cpu:0"):
    var = tf.get_variable(name=name,
                             shape=shape,
                             initializer=tf.contrib.layers.xavier_initializer())
    if wd is not None:
        weight_decay = tf.multiply(tf.nn.l2_loss(var), wd, name='weight_loss')
        tf.add_to_collection(name='losses', value=weight_decay)
    return var


def  losses_summary(total_loss):
        # 通过使用指数衰减，来维护变量的滑动均值。当训练模型时，维护训练参数的滑动均值是有好处的。在测试过程中使用滑动参数比最终训练的参数值本身，
        #会提高模型的实际性能（准确率）。apply()方法会添加trained variables的shadow copies，并添加操作来维护变量的滑动均值到shadow copies。average
        # 方法可以访问shadow variables，在创建evaluation model时非常有用。
        # 滑动均值是通过指数衰减计算得到的。shadow variable的初始化值和trained variables相同，其更新公式为
        # shadow_variable = decay * shadow_variable + (1 - decay) * variable
        average_op = tf.train.ExponentialMovingAverage(decay=0.9,name="avg")  # 创建一个新的指数滑动均值对象
        losses = tf.get_collection(key='losses')  # 从字典集合中返回关键字'losses'对应的所有变量，包括交叉熵损失和正则项损失
        # 创建‘shadow variables’,并添加维护滑动均值的操作
        maintain_averages_op = average_op.apply(losses + [total_loss])  # 维护变量的滑动均值，返回一个能够更新shadow variables的操作
        for i in losses + [total_loss]:
            tf.summary.scalar(i.op.name + '_raw', i)  # 保存变量到Summary缓存对象，以便写入到文件中
            tf.summary.scalar(i.op.name,
                          average_op.average(i))  # average() returns the shadow variable for a given variable.
        return maintain_averages_op  # 返回损失变量的更新操作


def one_step_train(total_loss, step):
    batch_count = int(train_samples_per_epoch / iris_input.BATCH_SIZE)  # 求训练块的个数
    decay_step = batch_count * num_epochs_per_decay  # 每经过decay_step步训练，衰减lr
    lr = tf.train.exponential_decay(learning_rate=initial_learning_rate,
                                    global_step=step,
                                   decay_steps=decay_step,
                                    decay_rate=learning_rate_decay_factor,
                                    staircase=True)
    tf.summary.scalar('learning_rate', lr)
    losses_movingaverage_op = losses_summary(total_loss)
    # tf.control_dependencies是一个context manager,控制节点执行顺序，先执行control_inputs中的操作，再执行context中的操作
    with tf.control_dependencies([losses_movingaverage_op]):
        trainer =tf.train.GradientDescentOptimizer(learning_rate=lr)
        
    
        gradient_pairs = trainer.compute_gradients(loss=total_loss)  # 返回计算出的（gradient, variable） pairs
    gradient_update = trainer.apply_gradients(grads_and_vars=gradient_pairs, global_step=step)  # 返回一步梯度更新操作
    # num_updates参数用于动态调整衰减率，真实的decay_rate =min(decay, (1 + num_updates) / (10 + num_updates)
    # Add histograms for trainable variables.
    for var in tf.trainable_variables():
        tf.summary.histogram(var.op.name, var)

    for grad, var in gradient_pairs:
        if grad is not None:
            tf.summary.histogram(var.op.name + '/gradients', grad)


    variables_average_op = tf.train.ExponentialMovingAverage(decay=moving_average_decay, num_updates=step)
    # tf.trainable_variables() 方法返回所有`trainable=True`的变量，列表结构
    maintain_variable_average_op = variables_average_op.apply(var_list=tf.trainable_variables())  # 返回模型参数变量的滑动更新操作
    with tf.control_dependencies(control_inputs=[gradient_update, maintain_variable_average_op]):
        gradient_update_optimizor = tf.no_op(name="train")  # Does nothing. Only useful as a placeholder for control edges
    return gradient_update_optimizor


def network(images):
    # 定义网络结构

    with tf.variable_scope(name_or_scope='conv1') as scope:
        weight = variable_on_cpu_with_collection(name='weights',
                                                 shape=(3, 3, 1, 32),
                                                 dtype=tf.float32,
                                                 wd=0.0)
        biases = variable_on_cpu(name='biases', shape=(32), dtype=tf.float32,
                               initializer=tf.constant_initializer(value=0.0))
        conv = tf.nn.conv2d(input=images, filter=weight, strides=(1, 1, 1, 1), padding='SAME')
        bias= tf.nn.bias_add(value=conv, bias=biases)
        conv1 = tf.nn.leaky_relu(bias, alpha=0.1, name=scope.name)
        _activation_summary(conv1)

    with tf.variable_scope(name_or_scope='conv2') as scope:
        weight = variable_on_cpu_with_collection(name='weight',
                                                 shape=(3, 3,32, 32),
                                                 dtype=tf.float32,
                                                 wd=0.0)
        biases = variable_on_cpu(name='biases', shape=(32), dtype=tf.float32,
                                 initializer=tf.constant_initializer(value=0.0))
        conv = tf.nn.conv2d(input=conv1, filter=weight, strides=(1, 1, 1, 1), padding='SAME')
        bias = tf.nn.bias_add(value=conv, bias=biases)
        conv2 = tf.nn.leaky_relu(bias, alpha=0.1, name=scope.name)
        _activation_summary(conv2)

    pool1 = tf.nn.max_pool(value= conv2, ksize=(1, 3, 3, 1), strides=(1, 2, 2, 1), padding='SAME',name="pool1")

    norm1 = tf.nn.lrn(input=pool1, depth_radius=4, bias=1.0, alpha=0.001 / 9.0, beta=0.75,name="norm1")

    with tf.variable_scope(name_or_scope='conv3') as scope:
        weight = variable_on_cpu_with_collection(name='weight',
                                                 shape=(3, 3, 32, 64),
                                                 dtype=tf.float32,
                                                 wd=0.0)
        biases = variable_on_cpu(name='bias', shape=(64), dtype=tf.float32,
                               initializer =tf.constant_initializer(value=0.1))
        conv = tf.nn.conv2d(norm1, weight, strides=(1, 1, 1, 1), padding='SAME')
        bias = tf.nn.bias_add(conv, biases)
        conv3 = tf.nn.leaky_relu(bias,alpha=0.1, name=scope.name)
        _activation_summary(conv3)

    with tf.variable_scope(name_or_scope='conv4') as scope:
        weight = variable_on_cpu_with_collection(name='weight',
                                                 shape=(3,3,64,64),
                                                 dtype=tf.float32,
                                                 wd=0.0)
        biases = variable_on_cpu(name='bias', shape=(64), dtype=tf.float32,
                               initializer=tf.constant_initializer(value=0.1))
        conv = tf.nn.conv2d(conv3, weight, strides=(1, 1, 1, 1), padding='SAME')
        bias = tf.nn.bias_add(conv, biases)
        conv4 = tf.nn.leaky_relu(bias,alpha=0.1,name=scope.name)
        _activation_summary(conv4)

    norm2 = tf.nn.lrn(input=conv4, depth_radius=4, bias=1.0, alpha=0.001 / 9.0, beta=0.75,name="norm2")

    pool2 = tf.nn.max_pool(value=norm2, ksize=(1, 2, 2, 1), strides=(1, 2, 2, 1), padding='SAME',name="pool2")
    # input tensor of shape `[batch, in_height, in_width, in_channels]
    reshaped_pool2 = tf.reshape(tensor=pool2, shape=(-1, 15 *90* 64))

    with tf.variable_scope(name_or_scope='local1') as scope:
        weight = variable_on_cpu_with_collection(name='weight',
                                                 shape=(15* 90 * 64,512),
                                                 dtype=tf.float32,
                                                 wd=0.001)
        biases = variable_on_cpu(name='bias', shape=(512), dtype=tf.float32,
                               initializer=tf.constant_initializer(value=0.1))
        #fc_mean,fc_var = tf.nn.moments(weight, axes=[0])
       # scale = tf.Variable(tf.ones([512]))
       # shift = tf.Variable(tf.zeros([512]))
      #  epsilon = 0.001
     #   weight = tf.nn.batch_normalization(weight,fc_mean,fc_var,shift,scale,epsilon)
        
        local1 = tf.nn.leaky_relu((tf.matmul(reshaped_pool2, weight) + biases),alpha=0.1,name=scope.name)
        _activation_summary(local1)

    with tf.variable_scope(name_or_scope='local2') as scope:
        weight = variable_on_cpu_with_collection(name='weight',
                                                 shape=(512, 128),
                                                 dtype=tf.float32,
                                                 wd=0.001)
        biases = variable_on_cpu(name='bias', shape=(128), dtype=tf.float32,
                               initializer=tf.constant_initializer(value=0.1))
        local2 = tf.nn.leaky_relu((tf.matmul( local1,weight) + biases),alpha=0.1, name=scope.name)
        _activation_summary(local2)

    with tf.variable_scope(name_or_scope='softmax_layer') as scope:
        weight = variable_on_cpu_with_collection(name='weight',
                                                 shape=(128, Class),
                                                  dtype=tf.float32,
                                                 wd=0.0)
        biases = variable_on_cpu(name='bias', shape=(Class), dtype=tf.float32,
                               initializer=tf.constant_initializer(value=0.0))
        softmax_linear = tf.nn.leaky_relu((tf.matmul(local2, weight) + biases), alpha=0.1, name=scope.name)
        _activation_summary(softmax_linear)
    return softmax_linear,local2


def center_loss(features, labels, alfa, nrof_classes):
    """获取center loss及center的更新op

    Arguments:
        features: Tensor,表征样本特征,一般使用某个fc层的输出,shape应该为[batch_size, feature_length].
        label: Tensor,表征样本label,非one-hot编码,shape应为[batch_size].
        alfa: 0-1之间的数字,控制样本类别中心的学习率,.
        num_classes: 整数,表明总共有多少个类别,网络分类输出有多少个神经元这里就取多少.

    Return：
        loss: Tensor,可与softmax loss相加作为总的loss进行优化.
        centers: Tensor,存储样本中心值的Tensor，仅查看样本中心存储的具体数值时有用.
  
    """
    nrof_features = features.get_shape()[1] # 获取向量特征长度
    centers = tf.get_variable('centers', [nrof_classes, nrof_features], dtype=tf.float32,
                                  initializer=tf.constant_initializer(0), trainable=False) # 生成可以共享变量的center

    labels = tf.reshape(labels, [-1])
    centers_batch = tf.gather(centers, labels)  # 取出对应Label
    diff = (1 - alfa) * (centers_batch - features)  # 求特征点到中心的距离并乘以一定的系数
    centers = tf.scatter_sub(centers, labels, diff)   # 更新center，输出将对应label的centers减去对应的diff,如果同一个标签出现多次减去多次
    loss=tf.nn.l2_loss(features-centers_batch,name="center_loss") 
    tf.add_to_collection('losses', 0.001*loss)     # 中心损失，将L2_loss的求2-范数
   # return loss, centers


def softmax_loss(features,logits, labels):
    labels = tf.cast(labels, dtype=tf.int32)
    sparse_labels = tf.reshape(labels,[batch_size,1])
    indices = tf.reshape(tf.range(batch_size),[batch_size,1])
    concated=tf.concat([indices,sparse_labels],1)
    dense_labels = tf.sparse_to_dense(concated,[batch_size,Class],1.0,0.0)
    cross_entropy = tf.nn.softmax_cross_entropy_with_logits(
      logits=logits, labels=dense_labels, name='cross_entropy_per_example')
    cross_entropy_mean = tf.reduce_mean(cross_entropy, name='cross_entropy')
    tf.add_to_collection('losses', cross_entropy_mean)
    center_loss(features, labels,0.5, Class)
    #cosine_loss(features,labels,0.2,Class,batch_size)

  # The total loss is defined as the cross entropy loss plus all of the weight
  # decay terms (L2 loss).
    return tf.add_n(tf.get_collection('losses'), name='total_loss')# 返回字典集合中key='losses'的子集中元素之和

# def cosine_loss(features, labels, alfa, nrof_classes,batch_size):
#     """获取center loss及center的更新op
#
#     Arguments:
#         features: Tensor,表征样本特征,一般使用某个fc层的输出,shape应该为[batch_size, feature_length].
#         label: Tensor,表征样本label,非one-hot编码,shape应为[batch_size].
#         alfa: 0-1之间的数字,控制样本类别中心的学习率,.
#         num_classes: 整数,表明总共有多少个类别,网络分类输出有多少个神经元这里就取多少.
#
#     Return：
#         loss: Tensor,可与softmax loss相加作为总的loss进行优化.
#         centers: Tensor,存储样本中心值的Tensor，仅查看样本中心存储的具体数值时有用.
#
#     """
#     nrof_features = features.get_shape()[1] # 获取向量特征长度
#     centers = tf.get_variable('centers', [nrof_classes, nrof_features], dtype=tf.float32,
#                                   initializer=tf.contrib.layers.xavier_initializer(), trainable=False) # 生成可以共享变量的center
#
#     labels = tf.reshape(labels, [-1])
#     centers_batch = tf.gather(centers, labels)  # 取出对应Label
#     diff = (1 - alfa) * (centers_batch - features)  # 求特征点到中心的距离并乘以一定的系数
#     centers = tf.scatter_sub(centers, labels, diff)   # 更新center，输出将对应label的centers减去对应的diff,如果同一个标签出现多次减去多次
#     features_norm = tf.sqrt(tf.reduce_sum(tf.square(features), axis=1))
#
#     centers_norm = tf.sqrt(tf.reduce_sum(tf.square(centers_batch), axis=1))
#     joint = tf.reduce_sum(tf.multiply(features,centers_batch), axis=1)
#
#     cosin =tf.div(joint, tf.multiply(features_norm,centers_norm))
#     cosin_loss=tf.reduce_sum(tf.subtract(tf.ones([batch_size],dtype=tf.float32),cosin),name="cosine_loss")
#    # cosin_loss=tf(batch_size-cosin,name="cosine_loss")
# #loss=tf.nn.l2_loss(features-centers_batch,name="center_loss")
#     tf.add_to_collection("losses",0.01*cosin_loss)
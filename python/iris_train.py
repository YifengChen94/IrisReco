import sys
import iris_input
import iris_model
import tensorflow as tf
import os
import numpy as np
from datetime import datetime
import iris_processing
import time

import os.path
BATCH_SIZE = iris_input.BATCH_SIZE
#BATCH_SIZE_TEST = 180

from iris_input import inputs
NUM_EPOCH=iris_input.num_epoch
PATH_TRAIN="/home/chen/IrisReco/python/"+str(iris_model.Class)+"train.tfrecords"
PATH_TEST="/home/chen/IrisReco/python/" +str(iris_model.Class)+"test.tfrecords"
max_iter_num = iris_input.num_epoch  # 设置参数迭代次数
checkpoint_path = "/home/chen/IrisReco/model_center_nor"  # 设置模型参数文件所在路径
event_log_path = '/home/chen/IrisReco/logdir'  # 设置事件文件所在路径，用于周期性存储Summary缓存对象

# flag=1 训练
# flag=0 测试
def train(flag):
    with tf.Graph().as_default():  # 指定当前图为默认graph
        global_step = tf.Variable(initial_value=0,
                                  trainable=False)  # 设置trainable=False,是因为防止训练过程中对global_step变量也进行滑动更新操作
        if (flag==1):
            path=PATH_TEST
        elif (flag==0):
            path=PATH_TRAIN# img_batch, label_batch = input_dataset.preprocess_input_data(data_path=PATH)  # 输入图像的预处理，包括亮度、对比度、图像翻转等操作
        image_batch,label_batch=inputs(batch_size=BATCH_SIZE,num_epochs=NUM_EPOCH,filename=path)
        logits,features = iris_model.network(image_batch)  # 图像信号的前向传播过程
        total_loss = iris_model.softmax_loss(features=features, logits=logits, labels= label_batch)  # 计算损失
        one_step_gradient_update =iris_model.one_step_train(total_loss, global_step)
        accuracy = tf.reduce_mean(tf.cast(tf.equal(tf.argmax(logits, 1), tf.cast(label_batch,tf.int64)), tf.float32))# 返回一步梯度更新操作
        # 创建一个saver对象，用于保存参数到文件中
        saver = tf.train.Saver(tf.global_variables()[:-2])  # tf.all_variables return a list of `Variable` objects
        all_summary_obj = tf.summary.merge_all()  # 返回所有summary对象先merge再serialize后的的字符串类型tensor
        #init = tf.group(tf.global_variables_initializer(),tf.local_variables_initializer())

        #softmax = tf.global_variables_initializer(scope="softmax_layer")
        softmax = tf.get_collection(tf.GraphKeys.TRAINABLE_VARIABLES,scope="softmax_layer")
        #centers = tf.get_variable(name="centers",reuse=True)
        #varlist= [softmax]
        init = tf.group(tf.variables_initializer(softmax),tf.local_variables_initializer())
        # log_device_placement参数可以记录每一个操作使用的设备，这里的操作比较多，就不需要记录了，故设置为False
        with tf.Session() as sess:

            sess.run(init)  # 变量初始化
            coord=tf.train.Coordinator()
            threads=tf.train.start_queue_runners(sess=sess,coord=coord)

            Event_writer = tf.summary.FileWriter(logdir=event_log_path, graph=sess.graph)

            ckpt = tf.train.get_checkpoint_state(checkpoint_path)
            if ckpt and ckpt.model_checkpoint_path:
                print(ckpt.model_checkpoint_path)
                saver.restore(sess,ckpt.model_checkpoint_path)
            if flag==1:
                try:
                    step=0
                    while not coord.should_stop() and step<10:
                        step+=1
                        acc=sess.run(accuracy)
                        print("Accuracy:%.4f"%acc)
                        
                except tf.errors.OutOfRangeError:
                    print("Done training of %d steps."%step)
                finally:
                    coord.request_stop()
                coord.join(threads)# 把所有变
                        
            elif flag==0:
                try:
                   step=0
                   while not coord.should_stop() and step<max_iter_num:
                       start_time = time.time()
                       _,loss_value=sess.run(fetches=[one_step_gradient_update,total_loss])
                       duration = time.time() - start_time
    
    
                       if step % 10 == 0:
                           num_examples_per_step=BATCH_SIZE
                           examples_per_second=num_examples_per_step/duration
                           sec_per_batch = float(duration)
                           format_str = ('%s: step %d, loss = %.2f (%.1f examples/sec; %.3f '
                                      'sec/batch)')
                           print(format_str % (datetime.now(),step,loss_value,
                                               examples_per_second, sec_per_batch))
                       step += 1
                       if step%50==0:
                           all_summaries = sess.run(all_summary_obj)
                           Event_writer.add_summary(summary=all_summaries,global_step=step)
    
    
                       if step  % 100 == 0 or step+1 == max_iter_num:
                           acc=sess.run(accuracy)
                           print("Accuracy:%.2f"%acc)
                           variables_save_path = os.path.join(checkpoint_path, 'model.ckpt')  # 路径合并，返回合并后的字符串
                           saver.save(sess, variables_save_path,
                                   global_step=step)
                except tf.errors.OutOfRangeError:
                    print("Done training of %d steps."%step)
                finally:
                    coord.request_stop()
                coord.join(threads)# 把所有变量（包括moving average前后的模型参数）保存在variables_save_path路径下



if __name__ == '__main__':
    train(flag=0)

import os
import numpy as np
import tensorflow as tf
import iris_processing
import iris_model
import iris_input
import time
from tensorflow.python import pywrap_tensorflow
ImagePath = "D:\\IrisReco\\image"                   # 图片读取路径
ModelPath = "D:\\IrisReco\\model_center_nor"       # 模型加载路径
var_list=["conv1","conv2","conv3","conv4","local1","local2"]
def features_vectors(model_path,iris_images):                     # 计算图片特征向量输出向量大小为(n*128),n为图片数量

    with tf.Graph().as_default():
        # images = iris_processing.Images(image_path)
        # iris_images = images.collect_images()
        iris_images = iris_input.per_standardizaiton(iris_images)
        features = iris_model.network(iris_images)
        saver = tf.train.Saver(tf.global_variables())
        inti = tf.group(tf.global_variables_initializer(),tf.local_variables_initializer())

        sess = tf.Session()
        ckpt = tf.train.get_checkpoint_state(model_path)
        if ckpt and ckpt.model_checkpoint_path:
            print(ckpt.model_checkpoint_path)
            saver.restore(sess,ckpt.model_checkpoint_path)
            reader = pywrap_tensorflow.NewCheckpointReader(ckpt.model_checkpoint_path)

        start_time = time.time()
        var= sess.run(tf.global_variables())
        varlist = tf.global_variables()
        for var1 in varlist:
            print("var_name:\n",var1.name)
        var_to_shape = reader.get_variable_to_shape_map()
        #print(var[0].name)
        results = sess.run([features])
        duration= time.time()-start_time
            #print("Cost time:%.3f"%duration)
    return results,duration,sess

def cos(vector1,vector2):
    # 计算向量相似度
    dot_product = 0.0;
    normA = 0.0;
    normB = 0.0;
    for a,b in zip(vector1,vector2):
        dot_product += a*b
        normA += a**2
        normB += b**2
    if normA == 0.0 or normB==0.0:
        return None
    else:
        return dot_product / ((normA*normB)**0.5)

# results,time = features_vectors(ModelPath,ImagePath)
# print(cos(results[0],results[1]))
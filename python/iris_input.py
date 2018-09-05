
import tensorflow as tf
import os

BATCH_SIZE = 50

train_samples_per_epoch = 1981
test_samples_per_epoch = 2967
num_epoch= 6000


def read_and_decode(filename_queue):

    #if not tf.gfile.Exists(filename_queue):
  #      raise ValueError('fail to find file:' + filename_queue)
    #filename_queue = tf.train.string_input_producer([filename],num_epochs=num_epochs)
    reader = tf.TFRecordReader()
    _, serialized_example = reader.read(filename_queue)
    features = tf.parse_single_example(serialized_example, features={
        "image_raw": tf.FixedLenFeature([], tf.string),
        "label": tf.FixedLenFeature([], tf.int64)})

    image = tf.decode_raw(features["image_raw"], tf.uint8)
    image = tf.reshape(image, [60, 360, 1])
    image = tf.cast(image, tf.float32)
    new_image = tf.image.random_brightness(image, max_delta=63)
    new_image = tf.image.random_contrast(new_image, lower=0.2, upper=1.8)
    final_image = tf.image.per_image_standardization(new_image)
    label = tf.cast(features["label"], tf.int32)
    return final_image, label

def inputs(batch_size,num_epochs,filename):
    if not tf.gfile.Exists(filename):
        raise ValueError('fail to find file:' + filename)
    filename_queue=tf.train.string_input_producer([filename],num_epochs=num_epochs)
    image,label=read_and_decode(filename_queue)
   # image = tf.image.resize_image_with_crop_or_pad(image,128,128)
    images,sparse_labels=tf.train.shuffle_batch([image,label],batch_size=batch_size,num_threads=8,capacity=200+3*batch_size,min_after_dequeue=40)
    return images,sparse_labels

def per_standardizaiton(images):
    img=[]
    for image in images:
        image=tf.image.per_image_standardization(image)
        img.append(image)
    return tf.reshape(img, [-1, 60, 360, 1])
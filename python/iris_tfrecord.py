import tensorflow as tf
import os
import numpy as np
import cv2
from sklearn.preprocessing import LabelEncoder
from sklearn.model_selection import StratifiedShuffleSplit

Path = "/home/chen/IrisReco/test_nor"

from iris_log import debug_log
class tfrecords(object):

    def __init__(self,path):
        self.path = path
        self.test_size = 0.1
        self.width = 360
        self.height = 60
        self.cwd = os.getcwd()


    def read_images(self):
        images = []
        labels = []
        for (dirpath,dirnames,filenames) in os.walk(self.path):
            for filename in filenames:
                if filename.endswith(".jpg"):
                    image_path = os.path.join(dirpath,filename)

                    #print("process:",image_path)
                    image = cv2.imread(image_path)
                    image = cv2.cvtColor(image,cv2.COLOR_RGB2GRAY)
                    label = image_path.split("/")[-3]+image_path.split("/")[-2]  #根据所属的文件夾的路徑作出相應修改

                    images.append(image)
                    labels.append(label)

        print("Successfully loading: {0} images".format(len(labels)))

        return np.array(images).reshape(-1,self.height,self.width),self.convert_tolabel(labels)

    def get_classes(self,label):

        classes = len(set(label))
        return classes

    def convert_tolabel(self,label):
        encoder = LabelEncoder()
        label = encoder.fit_transform(label)
        return label

    def get_split_samples(self):

        images,labels = self.read_images()

        if images.shape[0]!=labels.shape[0]:
            raise ValueError("Images size %d does not match label size %d" % (images[0],labels[0]))

        else:
            split = StratifiedShuffleSplit(n_splits=1 ,test_size=self.test_size,random_state=42)
            for train_index,test_index in split.split(images,labels):
              train_images, test_images = images[train_index],images[test_index]
              train_labels, test_labels = labels[train_index],labels[test_index]

        return train_images,test_images,train_labels,test_labels

    def generate_tfrecords(self):

        train_images,test_images,train_labels,test_labels = self.get_split_samples()

        classes = self.get_classes(train_labels)

        filename_train = os.path.join(self.cwd,str(classes)+"train.tfrecords")
        filename_test = os.path.join(self.cwd, str(classes)+"test.tfrecords")


        if os.path.exists(filename_train) or os.path.exists(filename_test):
            print("ValueError({0} or {1} already exsist".format(str(classes)+"train.tfrecords",str(classes)+"test.tfrecords"))
            debug_log().tfrecord_log(classes=classes,state=0)

        else:

            self.convert_tfrecords(filename_train,train_images,train_labels)
            self.convert_tfrecords(filename_test,test_images,test_labels)
            debug_log().tfrecord_log(classes=classes,state=1)

        return classes


    def convert_tfrecords(self,filename,images,labels):

        if images.shape[0]!=labels.shape[0]:
            raise ValueError("Images size %d does not match label size %d" % (images[0],labels[0]))

        else:

            writer =tf.python_io.TFRecordWriter(filename)

            rows = images.shape[1]
            cols = images.shape[2]

            for index in range(len(images)):
                image_raw = images[index].tostring()

                example = tf.train.Example(features=tf.train.Features(feature={
                    "height":self._int64_feature(rows),
                    "width": self._int64_feature(cols),
                    "label": self._int64_feature(int(labels[index])),
                    "image_raw": self._bytes_feature(image_raw)}))
                writer.write(example.SerializeToString())
            writer.close()


    def _int64_feature(self,value):

        return tf.train.Feature(int64_list=tf.train.Int64List(value=[value]))

    def _bytes_feature(self,value):

        return tf.train.Feature(bytes_list=tf.train.BytesList(value=[value]))

# if __name__ == '__main__':
#     tfr = tfrecords(path=Path)
#     print(tfr.generate_tfrecords())
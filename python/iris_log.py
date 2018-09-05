import logging
import os
import sys

class debug_log(object):

    def __init__(self):
        self.log_formnat = "%(asctime)s - %(levelname)s - %(message)s"
        self.path = os.path.join(os.getcwd(),"test.log")
        self.datefmt = '%a, %d %b %Y %H:%M:%S'
        logging.basicConfig(filename=self.path,level = logging.DEBUG,datefmt = self.datefmt,format = self.log_formnat)



    def processing_log (self,filename,state):            # 记录预处理结果，1表示预处理成功找到虹膜，0表示找到虹膜

        if (state):
            log_string = "Success loarding image {0}".format(filename)
            logging.debug(log_string)
        else:
            log_string = "Fail loading image {0}".format(filename)
            logging.error(log_string)


    def feature_log (self,score,image_id):                  #记录检测特征相似度
        log_string = "Features similarity:{0:.2f},: Image Id:{1}".format(score,image_id)
        logging.debug(log_string)

    def fuzzydetect_log(self,imagename,results):            #记录检测结果日志，1表示清晰图片，其余表示模糊图片
        if (results):
            log_string = "Success capture distinct image {0}".format(imagename)
            logging.debug(log_string)
        elif(results==0):
            log_string = "Fail loading fuzzy image {0}".format(imagename)
            logging.error(log_string)

    def tfrecord_log(self,classes,state):
        if (state):
            log_string = "Success generate {0} classes tfrecords".format(classes)
            logging.debug(log_string)
        else:
            log_string = "{0}train.tfrecods or {0}test.tfrecods already exsist".format(classes)
            logging.error(log_string)
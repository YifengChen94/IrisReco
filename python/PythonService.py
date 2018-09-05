# -*- coding: utf-8 -*-
"""
Created on Wed May  3 13:01:20 2017

@author: Chen yifeng
"""
import winerror
import servicemanager
import win32serviceutil   
import win32service   
import win32event  
import os
import sys
import time
import iris_sqlite
import  logging
from datetime import datetime


Log_file = os.getcwd().split("p")[0]+"log.out"
logging.debug("This messsage should go to the log file")
logging.basicConfig(filename= Log_file,level=logging.WARNING)
class PythonService(win32serviceutil.ServiceFramework):   
    #服务名  
    _svc_name_ = "IrisPython"
    #服务在windows系统中显示的名称  
    _svc_display_name_ = "Python Service Test Iris"
    #服务的描述  
    _svc_description_ = "This code is a Python service Test"  
  
    def __init__(self, args):   
        win32serviceutil.ServiceFramework.__init__(self, args)   
        self.hWaitStop = win32event.CreateEvent(None, 0, 0, None)
        self.run=True
        self.output= "D:\\IrisReco\\test2.txt"
        self.database = "D:\\IrisReco\\test.db"
        self.records = iris_sqlite.select_vertor_record(databasepath=self.database)
        # with open(self.output, 'a') as f:
        #     f.write(self.database)

        #if not os.path.exists(self.output):
         #   os.makedirs(self.output)p



    def SvcDoRun(self):


        while(self.run):
           # if (1==2):
            if (iris_sqlite.selct_reco_null(databasepath=self.database)):
                pass

            else:
                try:
                    path = iris_sqlite.insert_reco_record(databasepath=self.database,templet=self.records)
                    iris_sqlite.Delete_IrisImageInfo(databasepath=self.database)
                    for image_path in path:
                        os.remove(image_path.ImagePath)
                except:
                    logging.exception("Got excpetion on main handler")
                    raise

                # path = iris_sqlite.insert_reco_record(databasepath=DatabasePath,templet=records)
                # iris_sqlite.Delete_IrisImageInfo(databasepath=DatabasePath)
                # for image_path in path:
                #     os.remove(image_path.ImagePath)

            time.sleep(1.5)



        # 把自己的代码放到这里，就OK  
        # 等待服务被停止   
       # win32event.WaitForSingleObject(self.hWaitStop, win32event.INFINITE)
              
    def SvcStop(self):   
        # 先告诉SCM停止这个过程   
        self.ReportServiceStatus(win32service.SERVICE_STOP_PENDING)   
        # 设置事件   
        win32event.SetEvent(self.hWaitStop) 
        self.run = False

  
if __name__=='__main__':
    win32serviceutil.HandleCommandLine(PythonService)
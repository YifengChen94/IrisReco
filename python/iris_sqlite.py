import os
import numpy as np
import sqlite3
import iris_test
import iris_processing
import time
import uuid
import iris_log
import iris_fuzzydetect
DatabasePath = os.getcwd().split("p")[0]+"test.db"

def select_image_path (databasepath):
    results=[]
    conn = sqlite3.connect(databasepath)
    sql = "select ImageId ,ImagePath from Iris_Reco_Image"
    print(sql)
    cursor = conn.execute(sql)
    class Iris_path (object):
        pass
    for row in cursor:
        result = Iris_path()
        result.ImageId = row[0]
        result.ImagePath = row[1]
        results.append(result)

    return results


def insert_reco_record(databasepath,templet):    # 返回识别结果，插入识别识别信息
    path=select_image_path(databasepath)
    images = iris_processing.Images(path)
    success_images ,success_id,fail_id = images.collect_images
    results= []
    # iris_vectors, recotime,sess = iris_test.features_vectors(iris_test.ModelPath, success_images)
    # sess.close()
    # class Iris_record(object):
    #     pass
    #
    # for i in range(len(success_images)):
    #     tempory_result = []
    #
    #     for temp in templet:
    #         score = iris_test.cos(iris_vectors[0][i],np.array(temp.IrisVector))
    #         tempory_result.append(score)
    #
    #     result = Iris_record()
    #     number = tempory_result.index(max(tempory_result))
    #     fea_log = iris_log.debug_log()
    #
    #     fea_log.feature_log(max(tempory_result),success_id[i])
    #     if max(tempory_result)>=0.5:
    #         result.ImageId = success_id[i]
    #         result.RecoResult = 1
    #         result.AuditUserId = templet[number].AuditUserId
    #         result.RecoIrisId = templet[number].IrisId
    #         result.RecoTime = time.strftime("%a %b %d %H:%M:%S %Y", time.localtime())
    #     else:
    #         result.ImageId = success_id[i]
    #         result.RecoResult = 0
    #         result.AuditUserId =0
    #         result.RecoIrisId = 0
    #         result.RecoTime = time.strftime("%a %b %d %H:%M:%S %Y", time.localtime())
    #
    #     results.append(result)
    #
    # if (len(results)<5):
    #     for i in range(len(fail_id)):
    #         result= Iris_record()
    #         result.ImageId =  fail_id[i]
    #         result.RecoResult = 0
    #         result.AuditUserId = 0
    #         result.RecoIrisId = 0
    #         result.RecoTime = time.strftime("%a %b %d %H:%M:%S %Y", time.localtime())
    #         results.append(result)
    #
    #
    #
    # conn = sqlite3.connect(databasepath)
    # print("Connection success")
    # for i in range(len(results)):
    #     cursor = conn.cursor()
    #     sql="INSERT INTO Iris_Reco_Result (ImageId,RecoResult,AuditUserId ,RecoIrisId,RecoTime) \
    #     VALUES ('{0}',{1},'{2}','{3}','{4}')".format( results[i].ImageId, results[i].RecoResult,
    #      results[i].AuditUserId, results[i].RecoIrisId, time.strftime("%a %b %d %H:%M:%S %Y", time.localtime()))
    #     print(sql)
    #     cursor.execute(sql)
    #
    #     cursor.close()
    # conn.commit()
    # print("Submit success")
    # conn.close()
    # return path

def select_vertor_record(databasepath):             #查询表中所有模板
    results= []
    conn = sqlite3.connect(databasepath)
    print("Connection success")
    sql= "select IrisId, AuditUserId, IrisVector from Iris_Info"
  #  print(sql)
    cursor = conn.execute(sql)

    class IrisVectorRecord(object):
        pass
    for row in cursor:
        result = IrisVectorRecord()
        result.IrisId= row[0]
        result.AuditUserId = row[1]
        rows=[]
        for ro in row[2][1:-1].split(" "):
            if ro!=""and ro!="]":
                rows.append(ro)
        result.IrisVector = np.array(rows,dtype=np.float32)
        results.append(result)
    conn.close()
    return results

def selct_reco_null(databasepath):              #判断是否为空，非空返回1，空返回0
    conn = sqlite3.connect(databasepath)
   # print("Connection success")
    sql = "select * from Iris_Reco_Result"
    #  print(sql)
    cursor = conn.execute(sql)
    if (cursor.fetchall()!= []):
        conn.close()
        return 1
    else:
        conn.close()
        return 0


def Delete_IrisImageInfo(databasepath):
    conn = sqlite3.connect(databasepath)
    sql = "delete from Iris_Reco_Image"
    cursor = conn.execute(sql)
    conn.commit()
    conn.close()

class Iris_Info(object):

    def __init__(self, path, databasepath):
        self.impath  = path
        self.dbpath  = databasepath

    def insert_into_Iris_Reco_Image(self):
        results =[]
        image_path_list = []
        image_list = os.listdir(self.impath)
        for file in image_list:
            image_path  = os.path.join(self.impath,file)
            #if (iris_fuzzydetect.fuzzy_detect(image_path,file)):
            image_path_list.append(image_path)

        class Iris_path (object):
            pass
        for i in range(len(image_path_list)):
            result = Iris_path()
            result.ImageId = uuid.uuid1()
            result.ImagePath = image_path_list[i]
            results.append(result)
        conn = sqlite3.connect(self.dbpath)
        print("Connection success")
        for i in range(len(results)):
            cursor = conn.cursor()
            sql = "INSERT INTO Iris_Reco_Image (ImageId,CreateTime,ImagePath) \
                VALUES ('{0}','{1}','{2}')".format(results[i].ImageId,
            time.strftime("%a %b %d %H:%M:%S %Y",time.localtime()),results[i].ImagePath)
            print(sql)
            cursor.execute(sql)

            cursor.close()
        conn.commit()
        print("Submit success")
        conn.close()
        return results

    def Insert_into_Iris_Info (self):
        results = self.insert_into_Iris_Reco_Image()
        images = iris_processing.Images(results)


        success_images, success_id, fail_id = images.collect_images
        iris_vectors, recotime,sess = iris_test.features_vectors(iris_test.ModelPath, success_images)
        sess.close()
        conn = sqlite3.connect(self.dbpath)
        print("Connection success")
        for i in range(len(success_images)):
            cursor = conn.cursor()
            sql="INSERT INTO Iris_Info (IrisId,LeftRight,AuditUserId ,IrisVector,LastModifiedTime,LastModifiedBy) \
            VALUES ('{0}',0,'shirongrong','{1}','{2}','chen')".format(uuid.uuid1(),iris_vectors[0][i],
             time.strftime("%a %b %d %H:%M:%S %Y", time.localtime()))
            print(sql)
            cursor.execute(sql)

            cursor.close()
        conn.commit()
        print("Submit success")
        conn.close()



if __name__ == '__main__':
     Delete_IrisImageInfo(databasepath=DatabasePath)
     iris_info = Iris_Info(path="C:\\Users\\CYF\\Desktop\\iris_samples\\sunyimin",databasepath=DatabasePath)
     a = iris_info.insert_into_Iris_Reco_Image()
  #   insert_into_Iris_Info(path="D:\\IrisReco\\image",databasepath=DatabasePath)
     records = select_vertor_record(databasepath=DatabasePath)
     insert_reco_record(databasepath=DatabasePath,templet=records)
    # if ( selct_reco_null(databasepath=DatabasePath)):
    #     pass
    #
    # else:
    #     path = insert_reco_record(databasepath=DatabasePath, templet=records)
    #     Delete_IrisImageInfo(databasepath=DatabasePath)
    #     for image_path in path:
    #         os.remove(image_path.ImagePath)
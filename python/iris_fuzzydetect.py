import requests
import base64
import hashlib
import time
import random
import os,string,glob
from PIL import Image
from io import BytesIO
from urllib.parse import urlencode
from urllib import parse
import json
from requests.packages.urllib3.exceptions import InsecureRequestWarning
import iris_log
import json

class MsgTencent(object):
    def __init__(self,AppID=None,APPKey=None):
        self.app_id = AppID
        self.app_key = APPKey
        self.img_base64str = None

    def get_random_str(self):
        rule = string.ascii_lowercase + string.digits
        str = random.sample(rule,16)
        return "".join(str)

    def get_time_stamp(self):
        return  str(int(time.time()))

    def __get_image_base64str__(self,image):
        if not isinstance(image,Image): return None
        outputBuffer = BytesIO()
        bg.save(outputBuffer,format ="JPEG")
        imgbase64 = base64.b64encode(outputBuffer.getvalue())
        return imgbase64

    def __get_imgfile_base64str__(self,image):
        if not isinstance(image,str): return None
        if not os.path.isfile(image): return None

        with open(image,"rb") as fp:
            imgbase64 = base64.b64encode(fp.read())
            return imgbase64

    def get_img_base64str(self,image):
         if isinstance(image,str):
             self.img_base64str = self.__get_imgfile_base64str__(image)

         elif isinstance(image,Image):
             self.img_base64str = self.__get_imgfile_base64str__(image)

         return self.img_base64str.decode()

    def gen_ditc_md5(self,req_dict,app_key):
        if not isinstance(req_dict,dict): return  None
        if not isinstance(app_key,str): return  None

        try:
            sort_dict = sorted(req_dict.items(),key=lambda item:item[0],reverse=False)
            sort_dict.append(("app_key",app_key))
            sha = hashlib.md5()
            rawtext = urlencode(sort_dict).encode()
            sha.update(rawtext)
            md5text = sha.hexdigest().upper()

            if md5text:
                req_dict["sign" ] = md5text
                return md5text

        except Exception as e:
            return None


    def gen_req_dict(self,req_dict,app_id = None,app_key = None,time_stamp=None, nonce_str =None):

        if not req_dict.get("app_id"):
            if not app_id: app_id =self.app_id
            req_dict["app_id"] = app_id

        if not req_dict.get("time_stamp"):
            if not time_stamp:time_stamp = self.get_time_stamp()
            req_dict["time_stamp"] = time_stamp

        if not req_dict.get('nonce_str'):
            if not nonce_str: nonce_str= self.get_random_str()
            req_dict['nonce_str']= nonce_str

        if not app_key:app_key = self.app_key

        md5key = self.gen_ditc_md5(req_dict,app_key)
        return md5key


APPID = '1107027756'
APPKEY = 'ReOlVyh3vJEjlPdB'
TencentAPI = {
    # 基本文本分析API
    "nlp_wordseg": {
        'APINAME': '分词',
        'APIDESC': '对文本进行智能分词识别，支持基础词与混排词粒度',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/nlp/nlp_wordseg',
        'APIPARA': 'text'
    },
    "nlp_wordpos": {
        'APINAME': '词性标注',
        'APIDESC': '对文本进行分词，同时为每个分词标注正确的词性',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/nlp/nlp_wordpos',
        'APIPARA': 'text'
    },
    'nlp_wordner': {
        'APINAME': '专有名词识别',
        'APIDESC': '对文本进行专有名词的分词识别，找出文本中的专有名词',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/nlp/nlp_wordner',
        'APIPARA': 'text'
    },
    'nlp_wordsyn': {
        'APINAME': '同义词识别',
        'APIDESC': '识别文本中存在同义词的分词，并返回相应的同义词',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/nlp/nlp_wordsyn',
        'APIPARA': 'text'
    },

    # 计算机视觉--OCR识别API
    "ocr_generalocr": {
        'APINAME': '通用OCR识别',
        'APIDESC': '识别上传图像上面的字段信息',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/ocr/ocr_generalocr',
        'APIPARA': 'image'
    },
    "ocr_idcardocr": {
        'APINAME': '身份证OCR识别',
        'APIDESC': '识别身份证图像上面的详细身份信息',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/ocr/ocr_idcardocr',
        'APIPARA': 'image,card_type'
    },
    "ocr_bcocr": {
        'APINAME': '名片OCR识别',
        'APIDESC': '识别名片图像上面的字段信息',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/ocr/ocr_bcocr',
        'APIPARA': 'image'
    },
    "ocr_driverlicenseocr": {
        'APINAME': '行驶证驾驶证OCR识别',
        'APIDESC': '识别行驶证或驾驶证图像上面的字段信息',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/ocr/ocr_driverlicenseocr',
        'APIPARA': 'image,type'
    },
    "ocr_bizlicenseocr": {
        'APINAME': '营业执照OCR识别',
        'APIDESC': '识别营业执照上面的字段信息',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/ocr/ocr_bizlicenseocr',
        'APIPARA': 'image'
    },
    "ocr_creditcardocr": {
        'APINAME': '银行卡OCR识别',
        'APIDESC': '识别银行卡上面的字段信息',
        'APIURL': 'https://api.ai.qq.com/fcgi-bin/ocr/ocr_creditcardocr',
        'APIPARA': 'image'
    },
    "ocr_fuzzydection":
        {
            'APINAME': '图片模糊检测',
            'APIDESC': '返回模糊数值',
            'APIURL': 'https://api.ai.qq.com/fcgi-bin/image/image_fuzzy',
            'APIPARA': 'image'
        }
}


def ExecTecentAPI(*arg, **kwds):
    requests.packages.urllib3.disable_warnings(InsecureRequestWarning)
    if kwds.get('Apiname'): apiname = kwds.pop('Apiname')

    url = TencentAPI[apiname]['APIURL']
    name = TencentAPI[apiname]['APINAME']
    desc = TencentAPI[apiname]['APIDESC']
    para = TencentAPI[apiname]['APIPARA']

    tx = MsgTencent(APPID, APPKEY)

    Req_Dict = {}
    for key in para.split(','):
        value = None
        print(kwds)
        if kwds.get(key):  value = kwds.pop(key)
        if key == 'image':
            # 图像获取base64
            value = tx.get_img_base64str(value)
        if key == 'text':
            # 文本进行GBK编码
            value = value.encode('gbk')

        Req_Dict[key] = value
       # print(key, value, Req_Dict[key])

    # 生成请求包
    sign = tx.gen_req_dict(req_dict=Req_Dict)
    resp = requests.post(url, data=Req_Dict, verify=False)
    #print(name + '执行结果' + resp.text)
    return resp.text

def fuzzy_detect(filepath,filename):            #检测图片清晰度，若判断为false即代表图片清晰，返回值1，不清晰返回值为0
    str = ExecTecentAPI(Apiname="ocr_fuzzydection",image = filepath)
    str_result= json.loads(str)
   # print(dtypes(str_result))
    result= str_result["data"]["fuzzy"]
    #str_split = str.split(",")[2].split(":")[2]
    fuzzy_log = iris_log.debug_log()
    if (result == False):
        fuzzy_log.fuzzydetect_log(imagename=filename,results=1)
        return 1
    else:
        fuzzy_log.fuzzydetect_log(imagename=filename,results=0)
        return 0


# if __name__ == "__main__":
#     #名片ocr
#     file= 'C:\\Users\\CYF\\Desktop\\iris_samples\\chen_r\\WIN_20180705_19_54_10_Pro.jpg'
#
#     fuzzy_detect(file,"1")
#     print(rest)


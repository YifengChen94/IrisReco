/******************************************************************
 * Copyright(c)  Suzsoft Co., Ltd.
 * Description	 : 
 * CreateDate	 : 2006-04-13 10:31:41
 * Creater		 : Johnson Cao
 * LastChangeDate: 
 * LastChanger	 : 
 * Version Info	 : 
 * ******************************************************************/
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Suzsoft.Smart.EntityCore
{
	/// <summary>
	/// Entity object serializer method.
	/// </summary>
	public sealed class EntitySerializer
	{
		private EntitySerializer()
		{
			
		}

		#region 序列化
		/// <summary>
		/// 序列化成字符串
		/// </summary>
		/// <returns>序列化后的字符串</returns>
		public static string Serialiaze(object obj)
		{
			XmlSerializer xs = new XmlSerializer(obj.GetType());
			MemoryStream ms = new MemoryStream();
			XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
			xtw.Formatting = Formatting.Indented;
			xs.Serialize(xtw, obj);
			ms.Seek(0, SeekOrigin.Begin);
			StreamReader sr = new StreamReader(ms);
			string str = sr.ReadToEnd();
			xtw.Close();
			sr.Close();
			ms.Close();
			return str;
		}

		/// <summary>
		/// 序列化成文件
		/// </summary>
		/// <param name="fileName">目标文件路径</param>
		public static void Serialiaze(string fileName, object obj)
		{
			XmlSerializer xs = new XmlSerializer(obj.GetType()); 
			XmlTextWriter xtw = new XmlTextWriter(fileName, Encoding.UTF8); 
			xtw.Formatting = Formatting.Indented;
			xs.Serialize(xtw, obj);
			xtw.Close();
		}
		#endregion

		#region 反序列化
		/// <summary>
		/// 反序列化从文件
		/// </summary>
		/// <param name="fileName">Xml 文件</param>
		/// <param name="type">要生成的对象类型</param>
		/// <returns>反序列化后的对象</returns>
		public static object DeserializeFromFile(string fileName, Type type)
		{
			XmlSerializer xs = new XmlSerializer(type);
			XmlTextReader xtr = new XmlTextReader(fileName);
			object obj = xs.Deserialize(xtr);
			xtr.Close();
			return obj;
		}


		/// <summary>
		/// 反序列化从字符串
		/// </summary>
		/// <param name="xml">xml 字符串</param>
		/// <param name="type">要生成的对象类型</param>
		/// <returns>反序列化后的对象</returns>
		public static object Deserialize(string xml, Type type)
		{
			XmlSerializer xs = new XmlSerializer(type);
			StringReader sr = new StringReader(xml);
			object obj = xs.Deserialize(sr);
			sr.Close();
			return obj;
		}
		#endregion

		public static void SaveStringToFile(string fileName, string strXml)
		{
			StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
			sw.Write(strXml);
			sw.Close();
		}
	}
}

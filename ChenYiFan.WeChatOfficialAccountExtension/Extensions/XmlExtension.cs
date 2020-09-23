using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ChenYiFan.WeChatOfficialAccountExtension.Extensions
{
    public static class XmlExtension
    {
        public static T XmlToObj<T>(this string xmlStr)
        {
            //暴力方式将xml替换成我们需要的格式，这种做法只适用于以<xml></xml>包裹，同时在<![CDATA[]]>中没有包裹特殊字符的xml文件
            var body = xmlStr.Replace("<![CDATA[", "")
                .Replace("]]>", "")
                .Replace("<xml>", "")
                .Replace("\n</xml>", "")
                .Replace("\n", "\r\n");
            body =
                $"<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<{typeof(T).Name}>\r\n"
                + body + $"\r\n</{typeof(T).Name}>";

            T obj;

            var xmlSerializer = new XmlSerializer(typeof(T));
            try
            {
                var bytes = Encoding.UTF8.GetBytes(body);
                using var ms = new MemoryStream(bytes);
                using var st = new StreamReader(ms);
                obj = (T)xmlSerializer.Deserialize(st);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format($"couldn't parse xml: {xmlStr}: Type: {typeof(T).FullName}"), e);
            }

            return obj;
        }

        public static StringWriter ObjToXmlStringWriter<T>(this T obj)
        {
            var body = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(body, obj);

            return body;
        }
    }
}

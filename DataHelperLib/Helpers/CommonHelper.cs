using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataHelperLib.Helpers
{
    public class CommonHelper
    {
        #region ---------------- Serializer % Deserializer. JSON/XML ---------------
        
        //Serializer to JSON
        public static string JsonSerializer(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            string result = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                ms.Position = 0;
                using (StreamReader reader = new StreamReader(ms))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        //Deserializer from JSON
        public static T JsonDeserializer<T>(string json)
        {
            var ds = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            T result = (T)ds.ReadObject(ms);
            ms.Dispose();
            return result;
        }

        //Serializer to XML
        public static string XmlSerializer(object obj)
        {
            var result = string.Empty;
            if (obj != null)
            {
                var ser = new XmlSerializer(obj.GetType());
                using (var writer = new StringWriter())
                {
                    ser.Serialize(writer, obj);
                    writer.Flush();//清理缓存区
                    result = writer.GetStringBuilder().ToString();
                }
            }
            return result;
        }

        //Deserializer from XML
        public static T XmlDeserializer<T>(string xml)
        {
            T result = default(T);
            if (!string.IsNullOrWhiteSpace(xml))
            {
                var ser = new XmlSerializer(typeof(T));
                using (var reader = new StringReader(xml))
                {
                    result = (T)ser.Deserialize(reader);
                }
            }
            return result;
        }
        
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SystemIntegration.Utility
{
    public class XMLHelper
    {
        public static string SerializeToXml<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }
        public static T DeserializeFromXml<T>(string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }
    }
}

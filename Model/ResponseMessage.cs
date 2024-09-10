using MobileTopUpIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SystemIntegration.Model
{
    [XmlRoot("ResponseMessage")]
    public class ResponseMessage
    {
        public Header Header { get; set; }
        public ResponseBody Body { get; set; }
    }
}

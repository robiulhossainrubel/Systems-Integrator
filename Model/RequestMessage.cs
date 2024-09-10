using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SystemIntegration.Model
{
    [XmlRoot("RequestMessage")]
    public class RequestMessage
    {
        public Header Header { get; set; }
        public RequestBody Body { get; set; }
    }
}

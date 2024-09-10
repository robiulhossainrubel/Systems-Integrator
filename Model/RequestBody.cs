using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemIntegration.Model
{
    public class RequestBody
    {
        public int MessageID { get; set; }
        public string PhoneNumber { get; set; }
        public string Amount { get; set; }
    }
}

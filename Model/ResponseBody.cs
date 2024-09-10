using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemIntegration.Model
{
    public class ResponseBody
    {
        public string TransactionID { get; set; }
        public int TransactionNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Amount { get; set; }
        public string Result { get; set; }
    }
}

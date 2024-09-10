using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using SystemIntegration.Model;
using SystemIntegration.Utility;

namespace MobileTopUpIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create request
            var request = new RequestMessage
            {
                Header = new Header
                {
                    Identifier = "EZE",
                    MessageDate = DateTime.Now.ToString("ddMMyyyy"),
                    MessageTime = DateTime.Now.ToString("HHmmss")
                },
                Body = new RequestBody
                {
                    MessageID = 332526,
                    PhoneNumber = "630000000000",
                    Amount = "25"
                }
            };
            var request2 = new RequestMessage
            {
                Header = new Header
                {
                    Identifier = "EZE",
                    MessageDate = DateTime.Now.ToString("ddMMyyyy"),
                    MessageTime = DateTime.Now.ToString("HHmmss")
                },
                Body = new RequestBody
                {
                    MessageID = 332527,
                    PhoneNumber = "639999999999",
                    Amount = "25"
                }
            };

            // Serialize request object to XML
            string xmlRequest = XMLHelper.SerializeToXml(request);
            string xmlRequest2 = XMLHelper.SerializeToXml(request2);
            //Console.WriteLine("Serialized XML Request:");
            //Console.WriteLine(xmlRequest);

            // Convert XML to byte array
            byte[] byteArray = Encoding.UTF8.GetBytes(xmlRequest);
            byte[] byteArray2 = Encoding.UTF8.GetBytes(xmlRequest2);
            //Console.WriteLine("Request as Byte Array:");
            //Console.WriteLine(BitConverter.ToString(byteArray));

            // Sending request
            Console.WriteLine("Request Sending.............");

            // After receive preparing for response
            Console.WriteLine("Request Received.............");
            string btox = Encoding.UTF8.GetString(byteArray);
            var received_request = XMLHelper.DeserializeFromXml<RequestMessage>(btox);
            string btox2 = Encoding.UTF8.GetString(byteArray2);
            var received_request2 = XMLHelper.DeserializeFromXml<RequestMessage>(btox2);

            // Create response
            var responseobj = new ResponseMessage
            {
                Header = new Header
                {
                    MessageDate = DateTime.Now.ToString("ddMMyyyy"),
                    MessageTime = DateTime.Now.ToString("HHmmss"),
                },
                Body = new ResponseBody
                {
                    TransactionID = Guid.NewGuid().ToString(),
                    TransactionNumber = 1,
                    PhoneNumber = received_request.Body.PhoneNumber,
                    Amount = received_request.Body.Amount,
                    Result = "01"

                }
            };
            var responseobj2 = new ResponseMessage
            {
                Header = new Header
                {
                    MessageDate = DateTime.Now.ToString("ddMMyyyy"),
                    MessageTime = DateTime.Now.ToString("HHmmss"),
                },
                Body = new ResponseBody
                {
                    TransactionID = Guid.NewGuid().ToString(),
                    TransactionNumber = 12,
                    PhoneNumber = received_request2.Body.PhoneNumber,
                    Amount = received_request2.Body.Amount,
                    Result = "01"

                }
            };

            var res = XMLHelper.SerializeToXml(responseobj);
            var res2 = XMLHelper.SerializeToXml(responseobj2);


            // Response
            byte[] resbyteArray = Encoding.UTF8.GetBytes(res);
            Console.WriteLine("Response as Byte Array:");
            Console.WriteLine(BitConverter.ToString(resbyteArray));

            byte[] resbyteArray2 = Encoding.UTF8.GetBytes(res2);
            Console.WriteLine("Response as Byte Array:");
            Console.WriteLine(BitConverter.ToString(resbyteArray2));

            // After Receiving response
            Console.WriteLine("Response Received.............");


            
            string Responsexml = Encoding.UTF8.GetString(resbyteArray);
            string Responsexml2 = Encoding.UTF8.GetString(resbyteArray2);
            

            // Deserialize XML response to object
            var response = XMLHelper.DeserializeFromXml<ResponseMessage>(Responsexml);
            Console.WriteLine("Response Object:");
            Console.WriteLine($"Transaction ID: {response.Body.TransactionID}, Result: {response.Body.Result}");
            var response2 = XMLHelper.DeserializeFromXml<ResponseMessage>(Responsexml2);
            Console.WriteLine("Response Object:");
            Console.WriteLine($"Transaction ID: {response2.Body.TransactionID}, Result: {response2.Body.Result}");
        }
    } 
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class jquery
    {

        private static List<postparameter> parameters = new List<postparameter>();
        public static String URL = "http://api.lakerolmaker.com/main.php";

        public static void post()
        {
            WebClient webClient = new WebClient();
            NameValueCollection formData = new NameValueCollection();
            
            foreach(postparameter ob in parameters)
            {
                formData[ob.index] = ob.value;
            }
       
            byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
            // Här formateras svaeret till en sträng
            string responsefromserver = Encoding.UTF8.GetString(responseBytes);


            Console.WriteLine("hello");
            Console.WriteLine(responsefromserver);

            webClient.Dispose();

        }

        public static void addParamater(String index , String value)
        {
            parameters.Add(new postparameter(index, value));

        }

    }

    internal class postparameter
    {

        public String index;
        public String value;

        public postparameter(String indexInput ,String valueInput)
        {
            index = indexInput;
            value = valueInput;
        }

    }

}

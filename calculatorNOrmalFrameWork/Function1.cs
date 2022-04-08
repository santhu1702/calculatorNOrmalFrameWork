using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace calculatorNOrmalFrameWork
{
    public static class Function1
    {
        [FunctionName("Function1")]
        //public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        // {
        //     log.Info("C# HTTP trigger function processed a request.");


        //     string x = req.GetQueryNameValuePairs()
        //         .FirstOrDefault(q => string.Compare(q.Key, "x", true) == 0)
        //         .Value;

        //     string y = req.GetQueryNameValuePairs()
        //         .FirstOrDefault(q => string.Compare(q.Key, "y", true) == 0)
        //         .Value;


        //     int a = int.Parse(x);
        //     int b = int.Parse(y);


        //     return  req.CreateResponse(HttpStatusCode.OK, x+y);
        // }
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            int result;
            string op = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "op", true) == 0)
                .Value;

            string x = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "x", true) == 0)
                .Value;

            string y = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "y", true) == 0)
                .Value;

            int a = int.Parse(x);
            int b = int.Parse(y);

            if (op == "1")
                result = a + b;
            else if (op == "2")
                result = a - b;
            else if (op == "3")
                result = a * b;
            else if (op == "4")
                result = a / b;
            else
                result = 0;
            return req.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

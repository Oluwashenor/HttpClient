using System;
using System.Net;
using System.Net.Http.Headers;

namespace MyHttpClient
{

    public class Program
    {
         string getUrl = "https://jsonplaceholder.typicode.com/posts/1";

        public void http()
        {
            //Create Client 
            HttpClient client = new HttpClient();
            
        
            //Close Connection and release resources
            client.Dispose();   
        }

        static void httpGet()
        {
           string getUrl = "https://jsonplaceholder.typicode.com/posts/1";
           HttpClient client = new HttpClient();
           var uri = new Uri(getUrl);
           
            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("status Code =>"+statusCode);
            Console.WriteLine("status Code =>"+(int)statusCode);
           
            //Response 
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            client.Dispose();

        }


        static void httpGetInXML()
        {
            string getUrl = "https://jsonplaceholder.typicode.com/posts/1";
            //Headers
            HttpClient client = new HttpClient();
            HttpRequestHeaders requestHeader = client.DefaultRequestHeaders;
            requestHeader.Add("Accept", "application/xml");
            
            var uri = new Uri(getUrl);

            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("status Code =>" + statusCode);
            Console.WriteLine("status Code =>" + (int)statusCode);

            //Response 
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            client.Dispose();

        }

        static void Main(string[] args)
        {
            httpGetInXML();
            Console.WriteLine("Adesina");
        }
    }
   
}
                
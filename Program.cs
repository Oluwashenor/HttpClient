using System;

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
           client.Dispose();
        }
        static void Main(string[] args)
        {
            httpGet();
            Console.WriteLine("Adesina");
        }
    }
   
}
                
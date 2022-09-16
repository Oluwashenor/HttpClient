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

        static void httpUsingSendAsync()
        {
            string getUrl = "https://jsonplaceholder.typicode.com/posts/1";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> httpResponse = client.SendAsync(httpRequestMessage);
           
            
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

        static void UsingStatement()
        {
            //Using "Using", it automatically dispose the resource after use.

            string getUrl = "https://jsonplaceholder.typicode.com/posts/1";
            using (HttpClient client = new HttpClient())
            {
                using(HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    Task<HttpResponseMessage> httpResponse = client.SendAsync(httpRequestMessage);
                    using(HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
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
                    }
                }
            }
        }



        static void Main(string[] args)
        {
            UsingStatement();
            Console.WriteLine("Adesina");
        }
    }
   
}
                
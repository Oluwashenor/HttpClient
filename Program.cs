using MyHttpClient.Helpers;
using MyHttpClient.Model;
using MyHttpClient.Model.JsonModel;
using Newtonsoft.Json;
using Steeltoe.Common.Http;
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
                        //Console.WriteLine("status Code =>" + statusCode);
                        //Console.WriteLine("status Code =>" + (int)statusCode);

                        //Response 
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        //Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        Console.WriteLine(restResponse.ToString());
                    }
                }
            }
        }



        static void UsingStatementJsonDeserialization()
        {
            //Using "Using", it automatically dispose the resource after use.

            string getUrl = "https://jsonplaceholder.typicode.com/posts/1";
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    Task<HttpResponseMessage> httpResponse = client.SendAsync(httpRequestMessage);
                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        //Status Code
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        //Console.WriteLine("status Code =>" + statusCode);
                        //Console.WriteLine("status Code =>" + (int)statusCode);

                        //Response 
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        //Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        //Console.WriteLine(restResponse.ToString());
                        Post? post = JsonConvert.DeserializeObject<Post>(restResponse.ResponseContent);
                        Console.WriteLine(post?.ToString());
                    }
                }
            }
        }


        static void getUsingHelper()
        {
            Dictionary<string, string> httpHeaders = new Dictionary<string, string>();
            httpHeaders.Add("Accept", "application/json");
            //httpHeaders.Add("Authorization", "Basic Base64EncodedCredentials");//base64decode.org 
            Base64StringConverter.GetBase64String("username", "password");

            
        }



        static void Main(string[] args)
        {
            UsingStatementJsonDeserialization();
            Console.WriteLine("Adesina");
        }
    }
   
}
           


//Serialization - the process of converting the state of object to byte stream 
//Deserialization , its a process of retriving the object from the byte stream 
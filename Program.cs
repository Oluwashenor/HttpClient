using System;

namespace MyHttpClient
{

    public class Program
    {

        public void http()
        {
            //Create Client 
            HttpClient client = new HttpClient();
        
        
            //Close Connection and release resources
            client.Dispose();   
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Adesina");
        }
    }
   
}
                
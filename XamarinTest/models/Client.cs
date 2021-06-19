using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XamarinTest.models
{
    class Client
    {
        public static string Url = "https://localhost:44350/";
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}

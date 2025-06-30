using System;
using System.Net.Http;

namespace ModulaLocal.Services
{
    public class ApiService
    {
        public HttpClient Client { get; }

        public ApiService()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("http://10.20.29.65:8088/rerpapi/api")
            };
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public void SetAuthorizationHeader(string token)
        {
            if (Client.DefaultRequestHeaders.Contains("Authorization"))
                Client.DefaultRequestHeaders.Remove("Authorization");

            Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}
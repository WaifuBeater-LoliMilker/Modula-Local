using System;
using System.Net.Http;
using Xamarin.Essentials;

namespace ModulaLocal.Services
{
    public class ApiService
    {
        public HttpClient Client { get; }

        public ApiService()
        {
            var baseURL = Preferences.Get("BaseURL", null) ?? "http://10.20.29.65:8088/rerpapi/api/";
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseURL)
            };
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public void SetAuthorizationHeader(string token)
        {
            if (Client.DefaultRequestHeaders.Contains("Authorization"))
                Client.DefaultRequestHeaders.Remove("Authorization");
            Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
        public void RemoveToken()
        {
            Client.DefaultRequestHeaders.Remove("Authorization");
        }
        public void SetBaseUrl(string newBaseUrl)
        {
            if (string.IsNullOrWhiteSpace(newBaseUrl))
                throw new ArgumentException("Base URL cannot be empty.", nameof(newBaseUrl));
            Preferences.Set("BaseURL", newBaseUrl);
            Client.BaseAddress = new Uri(newBaseUrl);
        }

    }
}
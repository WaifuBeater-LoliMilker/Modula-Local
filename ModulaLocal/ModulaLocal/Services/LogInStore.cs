using ModulaLocal.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ModulaLocal.Services
{
    public class LogInStore
    {
        private LogInInfo info;
        public async Task<bool> LoginAsync(string username, string password)
        {
            var apiService = DependencyService.Get<ApiService>();

            var loginPayload = new
            {
                LoginName = username,
                PasswordHash = password
            };
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(loginPayload),
                Encoding.UTF8,
                "application/json");

            var response = await apiService.Client.PostAsync("home/login", jsonContent);

            if (!response.IsSuccessStatusCode)
                return false;

            var json = await response.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<LogInInfo>(json);

            apiService.SetAuthorizationHeader(info.access_token);

            return true;
        }
        public DateTime? GetTokenExpireTime()
        {
            return info.ExpiresDateTime;
        }
    }
}
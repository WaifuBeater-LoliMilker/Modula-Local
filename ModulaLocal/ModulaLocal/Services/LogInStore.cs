using ModulaLocal.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ModulaLocal.Services
{
    public class LogInStore
    {
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

            var response = await apiService.Client.PostAsync("/home/login", jsonContent);

            if (!response.IsSuccessStatusCode)
                return false;

            var json = await response.Content.ReadAsStringAsync();
            var loginResult = JsonConvert.DeserializeObject<LogInInfo>(json);

            apiService.SetAuthorizationHeader(loginResult.access_token);

            return true;
        }
    }
}
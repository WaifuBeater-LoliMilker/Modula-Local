using ModulaLocal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ModulaLocal.Services
{
    public class ModulaStore
    {
        public async Task<bool> GetAll()
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.GetAsync("/historyproductrtc/get-all");
            if (!response.IsSuccessStatusCode)
                return false;
            var json = await response.Content.ReadAsStringAsync();
            var modulaHistories = JsonConvert.DeserializeObject<ModulaHistories>(json);
            return true;
        }
        public async Task<bool> Update(ModulaStatusUpdate[] data)
        {
            var apiService = DependencyService.Get<ApiService>();
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json");
            var response = await apiService.Client.PostAsync("/historyproductrtc/save-data", jsonContent);
            if (!response.IsSuccessStatusCode)
                return false;
            var json = await response.Content.ReadAsStringAsync();
            
            return true;
        }
    }
}

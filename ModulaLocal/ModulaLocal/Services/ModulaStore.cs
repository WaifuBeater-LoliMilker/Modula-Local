using ModulaLocal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ModulaLocal.Services
{
    public class ModulaStore
    {
        public async Task<List<BorrowTicket>> GetAll()
        {
            var apiService = DependencyService.Get<ApiService>();
            var response = await apiService.Client.GetAsync("historyproductrtc/get-all");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Load dữ liệu không thành công, vui lòng thử lại");
            var json = await response.Content.ReadAsStringAsync();
            var modulaHistories = JsonConvert.DeserializeObject<ModulaHistories>(json);
            var borrows = modulaHistories.data.borrows;
            var returns = modulaHistories.data.returns;
            foreach (var item in borrows) item.IsBorrow = true;
            foreach (var item in returns) item.IsBorrow = false;
            return borrows.Concat(returns).ToList();
        }
        public async Task<bool> Update(List<ModulaStatusUpdate> data)
        {
            var apiService = DependencyService.Get<ApiService>();
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json");
            var response = await apiService.Client.PostAsync("historyproductrtc/save-data", jsonContent);
            if (!response.IsSuccessStatusCode)
                return false;
            var json = await response.Content.ReadAsStringAsync();
            
            return true;
        }
        public async Task<bool> CallTray(TrayInfo data)
        {
            var apiService = DependencyService.Get<ApiService>();
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json");
            var response = await apiService.Client.PostAsync("modulalocation/call-modula", jsonContent);
            if (!response.IsSuccessStatusCode)
                return false;
            var json = await response.Content.ReadAsStringAsync();

            return true;
        }
        public async Task<bool> ReturnTray(TrayInfo data)
        {
            var apiService = DependencyService.Get<ApiService>();
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(data),
                Encoding.UTF8,
                "application/json");
            var response = await apiService.Client.PostAsync("modulalocation/return-modula", jsonContent);
            if (!response.IsSuccessStatusCode)
                return false;
            var json = await response.Content.ReadAsStringAsync();

            return true;
        }
    }
}

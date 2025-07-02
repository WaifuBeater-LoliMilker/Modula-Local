using ModulaLocal.Services;
using ModulaLocal.Views;
using System;
using Xamarin.Forms;

namespace ModulaLocal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var apiService = DependencyService.Get<ApiService>();
            apiService.RemoveToken();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
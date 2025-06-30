using ModulaLocal.Models;
using ModulaLocal.Services;
using ModulaLocal.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ModulaLocal.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username, password;
        public string Username
        {
            get => username;
            set { username = value; }
        }
        public string Password
        {
            get => password;
            set { password = value; }
        }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var store = DependencyService.Get<LogInStore>();
            var loggedIn = await store.LoginAsync(username, password);
            if (loggedIn)
            {
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Thông báo", "Đăng nhập không thành công, vui lòng thử lại", "OK");
            }
        }
    }
}
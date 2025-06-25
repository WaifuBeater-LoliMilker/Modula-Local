using ModulaLocal.ViewModels;
using ModulaLocal.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ModulaLocal
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

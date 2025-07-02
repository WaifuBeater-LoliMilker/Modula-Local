using ModulaLocal.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.DataGrid;

namespace ModulaLocal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<ApiService>();
            DependencyService.Register<LogInStore>();
            DependencyService.Register<ModulaStore>();
            //DataGridComponent.Init();
            if (!Preferences.ContainsKey("BaseURL"))
            {
                Preferences.Set("BaseURL", "http://10.20.29.65:8088/rerpapi/api/");
            }
            MainPage = new AppShell();
            Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
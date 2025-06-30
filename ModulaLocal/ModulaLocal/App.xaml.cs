using ModulaLocal.Services;
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
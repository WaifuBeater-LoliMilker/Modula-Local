using ModulaLocal.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModulaLocal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(HideFlyoutQuery), "hideflyout")]
    public partial class SettingPage : ContentPage
    {
        private string _hideFlyoutQuery;

        public string HideFlyoutQuery
        {
            get => _hideFlyoutQuery;
            set
            {
                _hideFlyoutQuery = value;
                EvaluateFlyoutBehavior();
            }
        }
        public SettingPage()
        {
            InitializeComponent();
            var baseURL = Preferences.Get("BaseURL", "");
            BaseURLEntry.Text = baseURL;
        }
        private void EvaluateFlyoutBehavior()
        {
            if (!string.IsNullOrEmpty(HideFlyoutQuery) && HideFlyoutQuery == "true")
            {
                Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
            }
            else
            {
                Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            if (!string.IsNullOrEmpty(HideFlyoutQuery) && HideFlyoutQuery == "true")
            {
                Shell.Current.GoToAsync("//LoginPage");
                return true;
            }
            return false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var apiService = DependencyService.Get<ApiService>();
                apiService.SetBaseUrl(BaseURLEntry.Text);
                await DisplayAlert("Thông báo", "Dữ liệu lưu thành công", "OK");
            }
            catch
            {
                await DisplayAlert("Thông báo", "Thao tác thất bại", "OK");
            }
        }
    }
}
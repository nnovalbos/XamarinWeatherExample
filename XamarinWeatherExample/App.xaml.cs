using Xamarin.Forms;
using XamarinWeatherExample.Common;
using XamarinWeatherExample.Contracts.Services;

namespace XamarinWeatherExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.RegisterDependencies();

            
            
        }

        protected async override void OnStart()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

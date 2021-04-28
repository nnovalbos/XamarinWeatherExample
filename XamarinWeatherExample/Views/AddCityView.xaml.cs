
using Xamarin.Forms;
using XamarinWeatherExample.ViewModels;

namespace XamarinWeatherExample.Views
{
    public partial class AddCityView : ContentPage
    {
        public AddCityView()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var vm = BindingContext as AddCityViewModel;
            vm.Listener = null;
        }
    }
}

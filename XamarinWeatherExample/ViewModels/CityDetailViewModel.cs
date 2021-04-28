using System.Threading.Tasks;
using XamarinWeatherExample.Contracts.Services;
using XamarinWeatherExample.Models;
using XamarinWeatherExample.ViewModels.Base;

namespace XamarinWeatherExample.ViewModels
{
    public class CityDetailViewModel : BaseViewModel
    {
        private City _city;

        public CityDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            _city = new City();
        }

        public string Title
        {
            get => _city.CityName;
        }

        public override Task InitializeAsync(object parameter)
        {
            _city = parameter as City;
            OnPropertyChanged(nameof(Title));
            return base.InitializeAsync(parameter);
        }
    }
}

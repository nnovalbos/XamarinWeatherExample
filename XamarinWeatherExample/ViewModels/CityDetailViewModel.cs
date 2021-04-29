using System.Linq;
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
            IsBusy = true;
        }

        #region Properties
        public string Title => _city.CityName;

        public string Description => _city.Weather.Any() ? _city.Weather[0].Description : string.Empty;

        public string CityWeatherIcon => _city.Weather.Any() ? _city.Weather[0].Icon : string.Empty;

        public Temperature TemperatureValues
        {
            get => _city.Temperature;
        }
        #endregion

        public override Task InitializeAsync(object parameter)
        {
            IsBusy = true;
            _city = parameter as City;
            Draw();
            IsBusy = false;
            return base.InitializeAsync(parameter);
        }

        private void Draw()
        {
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(TemperatureValues));
            OnPropertyChanged(nameof(CityWeatherIcon));
        }
    }
}

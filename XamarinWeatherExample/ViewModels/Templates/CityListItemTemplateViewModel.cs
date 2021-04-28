using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWeatherExample.Contracts.Services;
using XamarinWeatherExample.Models;
using XamarinWeatherExample.ViewModels.Base;

namespace XamarinWeatherExample.ViewModels.Templates
{
    public class CityListItemTemplateViewModel : BaseViewModel
    {
        public City _city;

        public CityListItemTemplateViewModel(INavigationService navigationService): base(navigationService)
        {
            _city = new City();
        }

        public string CityName => _city.CityName;

        public string CityWeatherIcon => _city.Weather.Any() ? _city.Weather[0].Icon : string.Empty;

        public double CurrentTemperature => _city.Temperature.CurrentTemperature;

        public ICommand ShowCityDetailCommand => new Command(async () => await OnShowCityDetailCommand());

        public override Task InitializeAsync(object parameter)
        {
            _city = parameter as City;
            DrawCell();
            return base.InitializeAsync(parameter);
        }

        private void DrawCell()
        {
            OnPropertyChanged(nameof(CityName));
            OnPropertyChanged(nameof(CityWeatherIcon));
        }

        private async Task OnShowCityDetailCommand()
        {
            await navigationService.NavigateToAsync<CityDetailViewModel>(_city);
        }
    }
}

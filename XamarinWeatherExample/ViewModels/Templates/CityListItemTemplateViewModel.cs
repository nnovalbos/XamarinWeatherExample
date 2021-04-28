using System;
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

        public string CityWeatherIcon => "icon";

        public string CurrentTemperature => _city.CurrentTemperature;

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
        }

        private async Task OnShowCityDetailCommand()
        {
            await navigationService.NavigateToAsync<CityDetailViewModel>(_city);
        }
    }
}

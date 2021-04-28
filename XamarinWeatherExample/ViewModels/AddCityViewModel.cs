using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWeatherExample.Contracts.Listeners;
using XamarinWeatherExample.Contracts.Services;
using XamarinWeatherExample.Models;
using XamarinWeatherExample.ViewModels.Base;

namespace XamarinWeatherExample.ViewModels
{
    public class AddCityViewModel : BaseViewModel
    {
        private string _cityName;

        public AddCityViewModel(INavigationService navigationService) : base(navigationService)
        {
            _cityName = string.Empty;

            AddCommand = new Command(async (obj) => await OnAdd(), HasDataChange);
        }

        public string CityName
        {
            get => _cityName;
            set
            {
                _cityName = value;
                OnPropertyChanged();
                OnCanExecuteCommad();
            }
        }

        public ICityAddedListener Listener {get; set;}

        public Command AddCommand { get; private set; }

        public ICommand CancelCommand => new Command(async () => await OnCancel());

        public override Task InitializeAsync(object parameter)
        {
            Listener = parameter as ICityAddedListener;

            return base.InitializeAsync(parameter);
        }

        private async Task OnCancel()
        {
            await navigationService.CloseModalView();
        }

        private bool HasDataChange(object arg)
        {
            return !IsBusy && !string.IsNullOrEmpty(CityName);
        }

        private void OnCanExecuteCommad()
        {
            AddCommand.ChangeCanExecute();
        }

        private async Task OnAdd()
        {
            //TODO: realizamos petición para ver si existe la ciudad
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
            Listener?.CityAdded(new City { CityName = CityName, CurrentTemperature = "20"});
            await navigationService.CloseModalView();
        }
    }
}

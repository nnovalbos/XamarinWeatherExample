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
        private IWeatherService _weatherService;
        private IDialogService _dialogService;
        private string _cityName;

        public AddCityViewModel(INavigationService navigationService, IWeatherService weatherService,
            IDialogService dialogService) : base(navigationService)
        {
            
            _weatherService = weatherService;
            _dialogService = dialogService;

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

            try
            {
                IsBusy = true;
                var cityWithValues = await _weatherService.GetCityWeatherByName(CityName);

                Listener?.CityAdded(cityWithValues);
                await navigationService.CloseModalView();

            }
            catch(Exception e)
            {
                await _dialogService.ShowDialog("Error", e.Message, "OK");
            }

            IsBusy = false;

        }
    }
}

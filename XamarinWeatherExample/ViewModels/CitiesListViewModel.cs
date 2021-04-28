using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWeatherExample.Contracts.Listeners;
using XamarinWeatherExample.Contracts.Services;
using XamarinWeatherExample.Models;
using XamarinWeatherExample.ViewModels.Base;
using XamarinWeatherExample.ViewModels.Templates;

namespace XamarinWeatherExample.ViewModels
{
    public class CitiesListViewModel : BaseViewModel, ICityAddedListener
    {
        private ObservableCollection<CityListItemTemplateViewModel> _cities;
        
        public CitiesListViewModel(INavigationService navigationService) : base(navigationService)
        {
            _cities = new ObservableCollection<CityListItemTemplateViewModel>();
        }

        #region Properties
        public ObservableCollection<CityListItemTemplateViewModel> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand AddCommand => new Command(async() => await AddCity());

        

        #region Public Methods
        public override Task InitializeAsync(object parameter)
        {
            return base.InitializeAsync(parameter);
        }

        public void CityAdded(City city)
        {
            var vm = new CityListItemTemplateViewModel(navigationService);
            vm.InitializeAsync(city);
            Cities.Add(vm);
            
        }
        #endregion

        #region Private Methods
        private async Task AddCity()
        {
            await navigationService.NavigateToAsync<AddCityViewModel>(this);
        }
        #endregion

    }
}

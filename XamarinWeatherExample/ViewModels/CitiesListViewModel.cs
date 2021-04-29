using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            AddCommand = new Command(async (obj) => await AddCity(), (obj) =>!IsBusy);
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

        public new bool IsBusy
        {
            get => base.IsBusy;
            set
            {
                base.IsBusy = value;
                OnCanExecuteCommad();
            }
        }

        #endregion


        public Command AddCommand { get; private set; }


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
        private void OnCanExecuteCommad()
        {
            AddCommand.ChangeCanExecute();
        }

        private async Task AddCity()
        {
            await navigationService.NavigateToAsync<AddCityViewModel>(this);
        }
        #endregion
    }
}

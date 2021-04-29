using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWeatherExample.Contracts.Services;
using XamarinWeatherExample.ViewModels;
using XamarinWeatherExample.ViewModels.Base;
using XamarinWeatherExample.Views;

namespace XamarinWeatherExample.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> mappingViewModelToView;

        public NavigationService()
        {
            mappingViewModelToView = new Dictionary<Type, Type>();
            CreateMappings();
        }

        public async Task InitializeAsync()
        {
            Application.Current.MainPage = new Page();
            await NavigateToAsync<CitiesListViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return CustomNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return CustomNavigateToAsync(typeof(TViewModel), parameter);
        }

        public async Task CloseModalView()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async Task CustomNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreatePage(viewModelType, parameter);

            if (page is CitiesListView)
            {
                var nv = new NavigationPage(page);
                Application.Current.MainPage = nv;

            }
            else if (page is AddCityView)
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(page);
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
         
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = mappingViewModelToView[viewModelType];
            if (pageType == null) throw new Exception($"No page for view model:{viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private void CreateMappings()
        {
            mappingViewModelToView.Add(typeof(CitiesListViewModel), typeof(CitiesListView));
            mappingViewModelToView.Add(typeof(AddCityViewModel), typeof(AddCityView));
            mappingViewModelToView.Add(typeof(CityDetailViewModel), typeof(CityDetailView));
        }
    }
}

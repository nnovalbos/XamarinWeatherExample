using System;
using Autofac;
using XamarinWeatherExample.Contracts.Repositories;
using XamarinWeatherExample.Contracts.Services;
using XamarinWeatherExample.Repositories;
using XamarinWeatherExample.Services;
using XamarinWeatherExample.ViewModels;

namespace XamarinWeatherExample.Common
{
    public static class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            
            builder.RegisterType<CitiesListViewModel>();
            builder.RegisterType<AddCityViewModel>();
            builder.RegisterType<CityDetailViewModel>();


            builder.RegisterType<NavigationService>().As<INavigationService>();

            builder.RegisterType<WeatherApiRepository>().As<IGenericRepository>();

            _container = builder.Build();
        }

        public static object Resolve(Type typename)
        {
            return _container.Resolve(typename);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

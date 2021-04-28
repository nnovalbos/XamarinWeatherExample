using System.Threading.Tasks;
using XamarinWeatherExample.Common;
using XamarinWeatherExample.Contracts.Repositories;
using XamarinWeatherExample.Contracts.Services;
using XamarinWeatherExample.Models;
using XamarinWeatherExample.Models.ApiResponses;

namespace XamarinWeatherExample.Services
{
    public class WeatherService : IWeatherService
    {
        private IGenericRepository _repository;

        public WeatherService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public async Task<City> GetCityWeatherByName(string cityName)
        {
            var response = await _repository.GetAsync<CityResponse>(string.Format(ApiEndPoints.WeatherByName, cityName, ApiEndPoints.ApiKey));
            return City.CreateFromResponse(response);
        }
    }
}

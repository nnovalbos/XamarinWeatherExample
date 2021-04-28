using System.Threading.Tasks;
using XamarinWeatherExample.Models;

namespace XamarinWeatherExample.Contracts.Services
{
    public interface IWeatherService
    {
        Task<City> GetCityWeatherByName(string cityName);
    }
}
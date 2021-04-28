using System;
using System.Threading.Tasks;
using XamarinWeatherExample.Contracts.Repositories;

namespace XamarinWeatherExample.Repositories
{
    public class WeatherApiRepository : IGenericRepository
    {
        public WeatherApiRepository()
        {
        }

        public Task<T> GetAsync<T>(string uri, string authToken = "")
        {
            throw new NotImplementedException();
        }
    }
}

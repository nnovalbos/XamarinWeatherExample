using System.Threading.Tasks;

namespace XamarinWeatherExample.Contracts.Repositories
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri);
    }
}

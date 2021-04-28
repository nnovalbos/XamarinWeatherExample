using XamarinWeatherExample.Models;

namespace XamarinWeatherExample.Contracts.Listeners
{
    public interface ICityAddedListener
    {
        void CityAdded(City city);
    }
}

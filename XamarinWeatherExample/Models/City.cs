using System.Collections.Generic;
using XamarinWeatherExample.Models.ApiResponses;
using System.Linq;

namespace XamarinWeatherExample.Models
{
    public class City
    {
        public string CityName { get; set; } = string.Empty;

        public Temperature Temperature { get; set; } = new Temperature();

        public IList<Weather> Weather { get; set; } = new List<Weather>();

        public static City CreateFromResponse(CityResponse response)
        {
            var weatherList = new List<Weather>();
            response.Weather.ToList().ForEach(w => weatherList.Add(Models.Weather.CreateFromResponse(w)));

            return new City
            {
                CityName = response.CityName,
                Temperature = Temperature.CreateFromResponse(response.Temperature),
                Weather = weatherList
            };
        }
    }
}

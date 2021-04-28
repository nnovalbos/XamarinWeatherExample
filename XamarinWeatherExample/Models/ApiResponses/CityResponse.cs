using System.Collections.Generic;
using Newtonsoft.Json;

namespace XamarinWeatherExample.Models.ApiResponses
{
    public class CityResponse
    {

        [JsonProperty("name")]
        public string CityName { get; set; } = string.Empty;

        [JsonProperty("main")]
        public TemperatureResponse Temperature { get; set; } = new TemperatureResponse();

        [JsonProperty("weather")]
        public IList<WeatherResponse> Weather { get; set; } = new List<WeatherResponse>();
    }
}

using Newtonsoft.Json;

namespace XamarinWeatherExample.Models.ApiResponses
{
    public class TemperatureResponse
    {
        [JsonProperty("temp")]
        public double CurrentTemperature { get; set; } = 20.0;

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; } = 20.0;

        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; } = 20.0;
    }
}

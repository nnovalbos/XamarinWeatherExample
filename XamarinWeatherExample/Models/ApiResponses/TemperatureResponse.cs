using Newtonsoft.Json;

namespace XamarinWeatherExample.Models.ApiResponses
{
    public class TemperatureResponse
    {
        [JsonProperty("temp")]
        public double CurrentTemperature { get; set; } = double.MinValue;

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; } = double.MinValue;

        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; } = double.MinValue;
    }
}

using Newtonsoft.Json;

namespace XamarinWeatherExample.Models.ApiResponses
{
    public class WeatherResponse
    {
        [JsonProperty("main")]
        public string Main { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;
    }
}

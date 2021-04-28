using System;
using XamarinWeatherExample.Models.ApiResponses;

namespace XamarinWeatherExample.Models
{
    public class Weather
    {
        public string Main { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public static Weather CreateFromResponse(WeatherResponse response)
        {
            return new Weather
            {
                Main = response.Main,
                Description = response.Description,
                Icon = response.Icon
            };
        }
    }
}

using System;
using XamarinWeatherExample.Models.ApiResponses;

namespace XamarinWeatherExample.Models
{
    public class Temperature
    {
        public double CurrentTemperature { get; set; } = 20.0;

        public double MaxTemperature { get; set; } = 20.0;

        public double MinTemperature { get; set; } = 20.0;

        public static Temperature CreateFromResponse(TemperatureResponse response)
        {
            return new Temperature
            {
                CurrentTemperature = response.CurrentTemperature,
                MaxTemperature = response.MaxTemperature,
                MinTemperature = response.MinTemperature
            };
        }
    }
}

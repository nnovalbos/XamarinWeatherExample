using System;
using XamarinWeatherExample.Models.ApiResponses;

namespace XamarinWeatherExample.Models
{
    public class Temperature
    {
        public double CurrentTemperature { get; set; } = Double.MinValue;

        public double MaxTemperature { get; set; } = Double.MinValue;

        public double MinTemperature { get; set; } = Double.MinValue;

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

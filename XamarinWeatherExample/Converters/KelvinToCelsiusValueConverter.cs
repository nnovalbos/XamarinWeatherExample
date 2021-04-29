using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinWeatherExample.Converters
{
    public class KelvinToCelsiusValueConverter : IValueConverter
    {
        public KelvinToCelsiusValueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double kelvinValue && kelvinValue != Double.MinValue)
            {
                return $"{(int)(kelvinValue - 273.15)} ºC";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

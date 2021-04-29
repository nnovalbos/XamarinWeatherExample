using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinWeatherExample.Converters
{
    public class FahranheitToCelsiusValueConverter : IValueConverter
    {
        public FahranheitToCelsiusValueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double fahranheitValue && fahranheitValue!=Double.MinValue)
            {
                return $"{(int)(fahranheitValue - 273.15)} ºC";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

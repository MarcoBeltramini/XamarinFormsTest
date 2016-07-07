using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;

namespace Test.Converters
{
    public class TemperatureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (float.Parse(value.ToString()) != 0)
            {
                if (Math.Truncate(float.Parse(value.ToString())) == (value as float?))
                {
                    return (value as double?).Value.ToString("F1") + ".0°";
                }
                else
                {
                    return (value as double?).Value.ToString("F1") + "°";
                }
            }
            else
            {
                return "0°";
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            var stringValue = value.ToString();
            stringValue = stringValue.Replace("°", string.Empty);
            return double.Parse(stringValue);
        }
    }
}

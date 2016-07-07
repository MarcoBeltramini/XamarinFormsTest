using System;
using System.Reflection;
using System.Globalization;
using Xamarin.Forms;
using Test.Models;

namespace Test.Converters
{
    public class StringToFileImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value == null)
                return null;                      

            return ImageSource.FromResource((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
       
    }
}

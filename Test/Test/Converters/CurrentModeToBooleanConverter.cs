using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;
using Test.Models;

namespace Test.Converters
{
    public class CurrentModeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value != null)
            {
                if (value.ToString() == parameter.ToString())
                {
                    return true;
                }
                else
                { 
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (parameter != null)
            {
                switch (parameter.ToString())
                {
                    case "AUTO":
                        return Modes.AUTO;
                    case "MANU":
                        return Modes.MANU;
                    case "HDAY":
                        return Modes.HDAY;
                    case "JLLY":
                        return Modes.JLLY;
                    case "OFF":
                        return Modes.OFF;
                    default:
                        return Modes.OFF;
                } 
            }
            else
            {
                return Modes.OFF;
            }
        }
    }
}

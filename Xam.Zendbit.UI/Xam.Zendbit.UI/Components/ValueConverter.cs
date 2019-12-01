using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public class IsStringEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1 : 0;
        }
    }

    public class IsNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }
    }

    public class IsNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null;
        }
    }

    public class InversBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }

    public class MeterToKMConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value?.ToString(), out double meter))
            {
                return meter / 1000;
            }

            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0.0;
        }
    }

    public class StringToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0.0;
        }
    }

    public class StringSelectorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var toReplace = value?.ToString();
            var replacer = parameter?.ToString();
            if (!string.IsNullOrEmpty(toReplace) && !string.IsNullOrEmpty(replacer))
            {
                var splitReplacer = replacer.Split('|');
                if (splitReplacer.Length == 3)
                {
                    if (toReplace == splitReplacer[0])
                        return splitReplacer[1];
                    return splitReplacer[2];
                }
            }

            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }
    }

    public class IsStringNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 0 : 1;
        }
    }

    public class ReplaceStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var replacePair = parameter?.ToString().Split('|');
            var resultString = value?.ToString();
            if (replacePair.Length > 0)
            {
                foreach (var keyValStr in replacePair)
                {
                    var keyVal = keyValStr.Split(';');
                    if (keyVal.Length > 0)
                    {
                        resultString = resultString.Replace(keyVal[0], keyVal[1]);
                    }
                }
            }

            return resultString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 0 : 1;
        }
    }

    public class EmptyStringToDashConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString())
                ? "-" : value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.ToString().Equals("-")
                ? string.Empty
                : value.ToString();
        }
    }

    public class IsLessThanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out double val1)
                && double.TryParse(parameter.ToString(), out double val2))
            {
                return val1 < val2;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 0 : 1;
        }
    }

    public class IsLessThanOrEqualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out double val1)
                && double.TryParse(parameter.ToString(), out double val2))
            {
                return val1 <= val2;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 0 : 1;
        }
    }

    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().ToLower().Contains("true")
            ? ComponentResources.Self.GetResource(
                parameter.ToString(), ComponentResourcesEnum.ViewResources
                )
            : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ComponentResources.Self.GetResource(
                parameter.ToString(), ComponentResourcesEnum.ViewResources
            ) != null;
        }
    }

    public class LocalizeStringDatetimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string dateStr && !string.IsNullOrEmpty(dateStr))
            {
                var dtime = DateTime.Parse(dateStr);
                if (parameter is string format)
                    return dtime.ToString(format, culture);

                return dtime.ToString("g", culture);
            }
            else if (value is DateTime dateTime)
            {
                if (parameter is string format)
                    return dateTime.ToString(format, culture);

                return dateTime.ToString("g", culture);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }
    }

    public class IsListNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = new List<object>((IEnumerable<object>)value);
            return list.Any();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}

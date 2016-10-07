using System;
using System.Globalization;
using System.Windows.Data;

namespace RQEnchant
{
    public class Conv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            var val = Math.Round((double) value, 2);

            return val.ToString("### ### ### ### ###.###", culture).Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
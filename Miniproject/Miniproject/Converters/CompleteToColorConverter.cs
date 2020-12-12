using System;
using System.Globalization;
using Xamarin.Forms;

namespace Miniproject.Converters
{
    public class CompleteToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Color.FromHex("#28a745") : Color.FromHex("#dc3545");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

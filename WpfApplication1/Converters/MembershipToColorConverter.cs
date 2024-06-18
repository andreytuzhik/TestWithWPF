using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication1.Converters
{
    public class MembershipToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string membershipType && membershipType == "VIP")
            {
                return new SolidColorBrush(Colors.Gold);
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

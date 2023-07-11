using System.Globalization;

namespace CountryQuiz.Utils;

// All the code in this file is included in all platforms.
public class ShuffleValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string)
            return value?.ToString().ToList().OrderBy(_ => new Random().Next()).ToString();
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}


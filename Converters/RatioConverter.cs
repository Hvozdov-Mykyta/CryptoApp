using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;


namespace CryptoApp.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class RatioConverter : MarkupExtension, IValueConverter
    {
        private static RatioConverter _ratio;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double size = System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture);
            return size.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _ratio ?? (_ratio = new RatioConverter());
        }

    }
}

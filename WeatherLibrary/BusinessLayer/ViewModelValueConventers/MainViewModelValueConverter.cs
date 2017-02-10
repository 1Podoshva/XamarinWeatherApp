using System;
using MvvmCross.Platform.Converters;
namespace WeatherLibrary
{
	public class MainViewModelValueConverter : MvxValueConverter<string, string>
	{
		protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {

			if (parameter != null) {

				ConverterValueContext context = parameter as ConverterValueContext;

				if (context.Property == PropertyName.Temperature)
					return convertTemperature(value, context);

				else if (context.Property == PropertyName.WindSpeed)
					return convertWindSpeed(value, context);

				else if (context.Property == PropertyName.Humidity)
					return convertHumidity(value, context);

			}

			return base.Convert(value, targetType, parameter, culture);

		}

		private string convertWindSpeed(string value, ConverterValueContext context) {
			return String.Format("Wind: {0} meter/sec", value);
		}

		private string convertHumidity(string value, ConverterValueContext context) {
			return String.Format("Humidity: {0} %", value);
		}

		private static string convertTemperature(string value, ConverterValueContext context) {

			if (context.TempFormat == TemperatureFormat.Celsius)
				return String.Format("{0} °C", value);

			else if (context.TempFormat == TemperatureFormat.Fahrenheit)
				return String.Format("{0} °F", value);

			else if (context.TempFormat == TemperatureFormat.Kelvin)
				return String.Format("{0} K", value);

			return value;
		}
	}
}

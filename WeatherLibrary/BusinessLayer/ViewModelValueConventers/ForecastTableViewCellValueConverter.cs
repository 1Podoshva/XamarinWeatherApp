using System;
using MvvmCross.Platform.Converters;
namespace WeatherLibrary
{
	public class ForecastTableViewCellValueConverter : MvxValueConverter<float, string>
	{
		public ForecastTableViewCellValueConverter() {

		}

		protected override string Convert(float value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {

			if (parameter != null) {

				ConverterValueContext context = parameter as ConverterValueContext;

				if (context.Property == PropertyName.Temperature)
					return convertTemperature(ConverterValueContext.convertTemperature(value, context.TempFormat), context);

				else if (context.Property == PropertyName.WindSpeed)
					return convertWindSpeed(value, context);

				else if (context.Property == PropertyName.Humidity)
					return convertHumidity(value, context);

			}

			return base.Convert(value, targetType, parameter, culture);
		}

		private string convertWindSpeed(float value, ConverterValueContext context) {
			return String.Format("Wind: {0} mps", value);
		}

		private string convertHumidity(float value, ConverterValueContext context) {
			return String.Format("Humidity: {0} %", value);
		}

		private string convertTemperature(float value, ConverterValueContext context) {

			if (context.TempFormat == TemperatureFormat.Celsius)
				return String.Format("{0:0.#} °C", value);

			else if (context.TempFormat == TemperatureFormat.Fahrenheit)
				return String.Format("{0:0.#} °F", value);

			else if (context.TempFormat == TemperatureFormat.Kelvin)
				return String.Format("{0:0.#} K", value);

			return value.ToString();

		}
	}
}

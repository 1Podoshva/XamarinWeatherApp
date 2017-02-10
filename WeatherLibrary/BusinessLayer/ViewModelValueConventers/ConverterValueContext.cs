using System;
namespace WeatherLibrary
{
	public class ConverterValueContext
	{
		public TemperatureFormat TempFormat { get; private set; }
		public PropertyName Property { get; private set; }

		public ConverterValueContext(TemperatureFormat tempFormat, PropertyName property) {
			this.TempFormat = tempFormat;
			this.Property = property;
		}

		public static float convertTemperature(float kTemp, TemperatureFormat format) {

			if (format == TemperatureFormat.Fahrenheit)
				return 1.8f * (kTemp - 273.15f) + 32.0f;

			else if (format == TemperatureFormat.Celsius)
				return kTemp - 273.15f;

			return kTemp;

		}

	}
}

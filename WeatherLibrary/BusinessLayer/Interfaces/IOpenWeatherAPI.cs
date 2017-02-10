using System;
using System.Net;
using System.Collections.Generic;

namespace WeatherLibrary
{

	public interface IOpenWeatherAPI
	{

		void GetCurrentWeather(CityObject city, Action<WeatherObject, WebException> eventHandler);
		void GetWeatherByCityID(string cityID, Action<WeatherObject, WebException> eventHandler);
		void GetWeatherByCityName(string name, Action<WeatherObject, WebException> eventHandler);
		void GetWeatherByCoordinates(CityCoordinate coordinate, Action<WeatherObject, WebException> eventHandler);

		void GetForecastWeather(CityObject city, Action<List<WeatherObject>, WebException> eventHandler);
		void GetForecastWeatherByCityID(string cityID, Action<List<WeatherObject>, WebException> eventHandler);
		void GetForecastWeatherByCityName(string name, Action<List<WeatherObject>, WebException> eventHandler);
		void GetForecastWeatherCoordinates(CityCoordinate coordinate, Action<List<WeatherObject>, WebException> eventHandler);


	}

}

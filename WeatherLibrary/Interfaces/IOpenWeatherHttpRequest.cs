using System;
using System.Net;
using System.Collections.Generic;
namespace WeatherLibrary
{
	public interface IOpenWeatherHttpRequest
	{
		void GetWeatherWebRequests(CityObject city, Action<WeatherObject, WebException> eventHandler);
		void GetForecastWeatherWebRequests(CityObject city, Action<List<WeatherObject>, WebException> eventHandler);

	}
}

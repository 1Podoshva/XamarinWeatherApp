using System;
using System.Net;
using System.Collections.Generic;

namespace WeatherLibrary
{

	public class WeatherManager : IOpenWeatherAPI
	{

		#region property 

		// Private property
		//
		private static OpenWeatherHttpRequest _openWeatherHttpRequest = OpenWeatherHttpRequest.Instance;

		private static WeatherManager _instance;

		// Public property
		//

		public static WeatherManager Instance
		{

			get {

				if (_instance == null) {
					_instance = new WeatherManager();
				}

				return _instance;

			}

		}

		#endregion

		#region Init 

		private WeatherManager() {

		}


		#endregion

		#region public IOpenWeatherInterface
		#region public CurrentWeather
		//GetCurrentWeather

		public void GetCurrentWeather(CityObject city, Action<WeatherObject, WebException> eventHandler) {

			if (eventHandler != null) {

				if (city != null)
					_openWeatherHttpRequest.GetWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

			}

		}

		public void GetWeatherByCityID(string cityID, Action<WeatherObject, WebException> eventHandler) {

			CityObject city = new CityObject(cityID, null, new CityCoordinate(null, null));

			if (eventHandler != null) {

				if (city != null)
					_openWeatherHttpRequest.GetWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

			}

		}

		public void GetWeatherByCityName(string name, Action<WeatherObject, WebException> eventHandler) {

			CityObject city = new CityObject(null, name, new CityCoordinate(null, null));

			if (eventHandler != null) {

				if (city != null)
					_openWeatherHttpRequest.GetWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

			}

		}

		public void GetWeatherByCoordinates(CityCoordinate coordinate, Action<WeatherObject, WebException> eventHandler) {

			CityObject city = new CityObject(null, null, coordinate);

			if (eventHandler != null) {

				if (city != null)
					_openWeatherHttpRequest.GetWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

			}

		}

		#endregion

		#region ForecastWeather

		//GetForecastWeather

		public void GetForecastWeather(CityObject city, Action<List<WeatherObject>, WebException> eventHandler) {

			if (eventHandler != null)
				if (city != null)
					_openWeatherHttpRequest.GetForecastWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

		}

		public void GetForecastWeatherByCityID(string cityID, Action<List<WeatherObject>, WebException> eventHandler) {

			CityObject city = new CityObject(cityID, null, new CityCoordinate(null, null));

			if (eventHandler != null) {

				if (city != null)
					_openWeatherHttpRequest.GetForecastWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

			}

		}

		public void GetForecastWeatherByCityName(string name, Action<List<WeatherObject>, WebException> eventHandler) {

			CityObject city = new CityObject(null, name, new CityCoordinate(null, null));

			if (eventHandler != null) {

				if (city != null)
					_openWeatherHttpRequest.GetForecastWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

			}

		}

		public void GetForecastWeatherCoordinates(CityCoordinate coordinate, Action<List<WeatherObject>, WebException> eventHandler) {

			CityObject city = new CityObject(null, null, coordinate);

			if (eventHandler != null) {

				if (city != null)
					_openWeatherHttpRequest.GetForecastWeatherWebRequests(city, eventHandler);
				else
					eventHandler(null, new WebException("City is null"));

			}

		}

		#endregion
		#endregion


	}

}

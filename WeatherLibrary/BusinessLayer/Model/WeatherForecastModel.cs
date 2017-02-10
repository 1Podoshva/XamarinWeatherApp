using System;
using System.Collections.Generic;
using System.Net;

namespace WeatherLibrary
{
	public class WeatherForecastModel : BaseWeatherModel
	{

		//private action events 
		//

		private event Action<List<WeatherObject>> _didUpdateWeaherEventHandler;

		//private propertes 
		//

		private CityObject _currentCity;
		private List<WeatherObject> _forecast;

		//public propertes
		//

		public List<WeatherObject> Forecast
		{
			get { return _forecast; }
			private set { _forecast = value; }
		}

		#region Init

		public WeatherForecastModel(CityObject city) : base() {
			_currentCity = city;

		}

		#endregion

		#region PublicMethods

		public void GetForecastWeather(Action<List<WeatherObject>> DidUpdateWeaherEventHandler, Action<WebException> ErrorUpdateWeaherEventHandler) {

			_didUpdateWeaherEventHandler += DidUpdateWeaherEventHandler;
			this.ErrorUpdateWeaherEventHandler += ErrorUpdateWeaherEventHandler;

			weatherManager.GetForecastWeather(_currentCity, weatherEventHandler);

		}

		#endregion

		#region PrivateMethods

		private void weatherEventHandler(List<WeatherObject> weatherList, WebException webExeptin) {

			if (webExeptin == null) {

				if (weatherList != null) {

					this.Forecast = weatherList;

					if (_didUpdateWeaherEventHandler != null)
						_didUpdateWeaherEventHandler(this.Forecast);

				}


				else
					System.Diagnostics.Debug.WriteLine("-- ERROR: weather object is nil --");

			}
			else {

				System.Diagnostics.Debug.WriteLine("-- ERROR: {0} --", webExeptin.Message);

				if (this.ErrorUpdateWeaherEventHandler != null)
					this.ErrorUpdateWeaherEventHandler(webExeptin);

			}

		}

		#endregion

	}
}

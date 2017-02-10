using System;
using System.Net;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Location;

namespace WeatherLibrary
{
	public class WatherCurrentModel : BaseWeatherModel
	{
		//Private 
		//

		private event Action<WeatherObject> _didUpdateWeaherEventHandler;

		//Public event
		//

		public Action<WeatherObject> DidUpdateWeaherEventHandler
		{
			get { return _didUpdateWeaherEventHandler; }
			set { _didUpdateWeaherEventHandler = value; }
		}

		//Pubic property
		//

		public WeatherObject CurrentWeather { get; protected set; }

		#region Init

		public WatherCurrentModel(CityObject city) : base() {
			CurrentWeather = new WeatherObject(city);
		}


		#endregion

		#region PublicMethods

		public void GetCurrentWeather(Action<WeatherObject> DidUpdateWeaherEventHandler, Action<WebException> ErrorUpdateWeaherEventHandler) {

			this.DidUpdateWeaherEventHandler += DidUpdateWeaherEventHandler;
			this.ErrorUpdateWeaherEventHandler += ErrorUpdateWeaherEventHandler;

			weatherManager.GetCurrentWeather(CurrentWeather.City, weatherEventHandler);

		}

		#endregion

		#region ProtectedMethods

		protected void weatherEventHandler(WeatherObject weatherObject, WebException webExeptin) {

			if (webExeptin == null) {

				if (weatherObject != null) {

					this.CurrentWeather = weatherObject;

					if (this.DidUpdateWeaherEventHandler != null)
						this.DidUpdateWeaherEventHandler(this.CurrentWeather);

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

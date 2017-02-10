using System;
using System.Collections.Generic;
using System.Net;
using MvvmCross.Core.ViewModels;
namespace WeatherLibrary
{
	public class WeatherForecastViewModel : BaseWeatherViewModel, IWeatherControl
	{
		#region Property

		//Private propertes
		//

		private WeatherForecastModel _model;
		private List<WeatherObject> _forecast;

		//Public propertes
		//

		public List<WeatherObject> Forecast
		{
			get { return _forecast; }
			set {
				_forecast = value;
				RaisePropertyChanged(() => Forecast);
			}
		}

		#endregion

		#region Init

		public WeatherForecastViewModel(WeatherForecastModel model) : base() {
			_model = model;
			_forecast = model.Forecast;
		}

		public void update() {

			if (DidStartUpadateWeather != null)
				DidStartUpadateWeather();

			_model.GetForecastWeather(DidUpdateWeaherEventHandler, ErrorUpdateWeaherEventHandler);

		}

		#endregion

		#region ProtectedMethods

		protected void DidUpdateWeaherEventHandler(List<WeatherObject> forecast) {

			if (DidEndUpadateWeather != null)
				DidEndUpadateWeather();

			this.Forecast = forecast;


		}

		protected void ErrorUpdateWeaherEventHandler(WebException webExeption) {

			if (DidEndUpadateWeather != null)
				DidEndUpadateWeather();

		}

		#endregion


	}
}

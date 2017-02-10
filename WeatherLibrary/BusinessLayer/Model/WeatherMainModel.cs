using System;
using System.Net;
using System.Collections.Generic;

namespace WeatherLibrary
{
	public class WeatherMainModel : WatherCurrentModel
	{


		#region Property

		//Private
		//

		private WeatherForecastModel _forecastWeather;

		//Public
		//

		public WeatherForecastModel ForecastWeather
		{
			get { return _forecastWeather; }
			protected set { _forecastWeather = value; }
		}

		#endregion

		#region Init

		public WeatherMainModel(CityObject city) : base(city) {

			ForecastWeather = new WeatherForecastModel(city);

		}

		#endregion


	}
}

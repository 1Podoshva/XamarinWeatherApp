using System;
using MvvmCross.Core.ViewModels;


namespace WeatherLibrary
{
	public class BaseWeatherViewModel : MvxViewModel
	{

		public new TemperatureFormat TemperatureFormat = TemperatureFormat.Celsius;

		// PublicAction
		private event Action _didStartUpadateWeather;
		private event Action _didEndUpadateWeather;

		public Action DidStartUpadateWeather
		{
			get { return _didStartUpadateWeather; }
			set { _didStartUpadateWeather = value; }
		}

		public Action DidEndUpadateWeather
		{
			get { return _didEndUpadateWeather; }
			set { _didEndUpadateWeather = value; }
		}

		public BaseWeatherViewModel() : base() {

		}

	}
}

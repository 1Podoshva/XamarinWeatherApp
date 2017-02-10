using System;
using System.Net;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace WeatherLibrary
{

	public class WeatherMainViewModel : BaseWeatherViewModel
	{

		#region Property

		// Protected property

		protected WeatherMainModel WeatherModel { get; set; }

		// Private property	

		private string _temperature;
		private string _main;
		private string _windSpeed;
		private string _humidity;
		private string _city;
		private List<WeatherObject> _forecast;
		private MvxCommand _update;

		// Public property

		public string Temperature
		{
			get { return _temperature; }
			private set { _temperature = value; RaisePropertyChanged(() => Temperature); }
		}

		public string Main
		{
			get { return _main; }
			private set { _main = value; RaisePropertyChanged(() => Main); }
		}

		public string WindSpeed
		{
			get { return _windSpeed; }
			private set { _windSpeed = value; RaisePropertyChanged(() => WindSpeed); }
		}

		public string Humidity
		{
			get { return _humidity; }
			private set { _humidity = value; RaisePropertyChanged(() => Humidity); }
		}

		public string City
		{
			get { return _city; }
			private set { _city = value; RaisePropertyChanged(() => City); }
		}

		public List<WeatherObject> Forecast
		{
			get { return _forecast; }
			private set { _forecast = value; RaisePropertyChanged(() => Forecast); }
		}

		public ICommand Update
		{
			get {
				_update = _update ?? new MvxCommand(update);
				return _update;
			}
		}

		#endregion

		#region Init

		public WeatherMainViewModel(WeatherMainModel model) : base() {
			this.WeatherModel = model;
		}

		#endregion

		#region IWeatherView

		protected void update() {

			if (DidStartUpadateWeather != null)
				DidStartUpadateWeather();

			this.WeatherModel.GetCurrentWeather(DidUpdateWeaherEventHandler, ErrorUpdateWeaherEventHandler);
			this.WeatherModel.ForecastWeather.GetForecastWeather(DidUpdateForecastWeaherEventHandler, ErrorUpdateWeaherEventHandler);

		}

		#endregion

		#region ProtectedMethods

		protected void DidUpdateWeaherEventHandler(WeatherObject weatherObj) {

			if (DidEndUpadateWeather != null)
				DidEndUpadateWeather();

			float temperature = ConverterValueContext.convertTemperature(WeatherModel.CurrentWeather.MainInfo.Temp, this.TemperatureFormat);

			Temperature = string.Format("{0:0.#}", temperature);
			Main = WeatherModel.CurrentWeather.Main;
			WindSpeed = WeatherModel.CurrentWeather.MainInfo.Wind.Speed.ToString();
			Humidity = WeatherModel.CurrentWeather.MainInfo.Humidity.ToString();
			City = WeatherModel.CurrentWeather.City.Name;


		}

		protected void DidUpdateForecastWeaherEventHandler(List<WeatherObject> forecast) {

			if (DidEndUpadateWeather != null)
				DidEndUpadateWeather();

			Forecast = forecast;

		}

		protected void ErrorUpdateWeaherEventHandler(WebException webExeption) {

			if (DidEndUpadateWeather != null)
				DidEndUpadateWeather();

		}

		#endregion

	}
}

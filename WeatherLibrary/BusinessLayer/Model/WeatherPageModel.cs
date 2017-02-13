using System;
using System.Collections.Generic;
using MvvmCross.Plugins.Location;
using System.ComponentModel;
using MvvmCross.Platform;

namespace WeatherLibrary
{
	public class WeatherPageModel
	{
		private List<WeatherMainModel> _mainModels;
		private IDataService _dataService;

		public List<WeatherMainModel> MainModels
		{
			get {
				return _mainModels;
			}
			private set { _mainModels = value; }
		}

		public WeatherPageModel(IDataService dataService) {
			_dataService = dataService;

			this.MainModels = new List<WeatherMainModel>();

			InitWeatherMainModels();

		}

		private void InitWeatherMainModels() {
			foreach (CityEntity city in _dataService.Cities()) {
				this.MainModels.Add(new WeatherMainModel(new CityObject(null, city.Name, new CityCoordinate(null, null))));
			}
		}

		public void UpdateMianModels() {
			this.MainModels = new List<WeatherMainModel>();
			InitWeatherMainModels();
		}


	}

}

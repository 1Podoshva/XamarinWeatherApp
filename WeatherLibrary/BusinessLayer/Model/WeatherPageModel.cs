using System;
using System.Collections.Generic;
namespace WeatherLibrary
{
	public class WeatherPageModel
	{
		private List<WeatherMainModel> _mainModels;

		public List<WeatherMainModel> MainModels
		{
			get { return _mainModels; }
			private set { _mainModels = value; }
		}

		public WeatherPageModel() {

			this.MainModels = new List<WeatherMainModel>();

			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "London", new CityCoordinate(null, null))));
			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "New York", new CityCoordinate(null, null))));
			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "Kiev", new CityCoordinate(null, null))));
			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "Shklow", new CityCoordinate(null, null))));


		}
	}
}

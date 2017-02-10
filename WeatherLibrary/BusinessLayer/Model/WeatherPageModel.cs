﻿using System;
using System.Collections.Generic;
using MvvmCross.Plugins.Location;
using System.ComponentModel;
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
			InitWeatherMainModels();

		}

		private void InitWeatherMainModels() {

			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "Minsk", new CityCoordinate(null, null))));
			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "London", new CityCoordinate(null, null))));
			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "New York", new CityCoordinate(null, null))));
			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "Kiev", new CityCoordinate(null, null))));
			this.MainModels.Add(new WeatherMainModel(new CityObject(null, "Shklow", new CityCoordinate(null, null))));


		}

	}

}

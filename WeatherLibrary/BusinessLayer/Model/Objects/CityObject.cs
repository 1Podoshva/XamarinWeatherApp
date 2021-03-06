﻿using System;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Location;

namespace WeatherLibrary
{

	public struct CityCoordinate
	{

		public string Longitude;
		public string Latitude;

		public CityCoordinate(string latitude, string longitude) {

			this.Latitude = latitude;
			this.Longitude = longitude;

		}

	}

	public class CityObject : BaseObject
	{

		public string Id { get; private set; }
		public string Name { get; private set; }
		public CityCoordinate Coordinates { get; set; }


		public CityObject() : base() {

		}

		public CityObject(string id, string name, CityCoordinate coordinates) : base() {

			this.Id = id;
			this.Name = name;
			this.Coordinates = coordinates;

		}

	}



}

using System;
using SQLite;
using Newtonsoft.Json.Bson;

namespace WeatherLibrary
{
	public class CityEntity
	{
		[PrimaryKey, AutoIncrement]
		public int ObjID { get; set; }
		public string Name { get; set; }

		public CityEntity() {

		}
	}
}

using System;
namespace WeatherLibrary
{

	public class Wind
	{
		public float Speed { get; set; }
		public float Deg { get; set; }

	}

	public class WeatherMainInfo
	{
		public float Temp { get; set; }
		public float Pressure { get; set; }
		public float Humidity { get; set; }
		public float Temp_min { get; set; }
		public float Temp_max { get; set; }
		public Wind Wind { get; set; }

	}


	public class DayInfo
	{
		public float Temp { get; set; }
		public float TempNight { get; set; }
		public float TempEve { get; set; }
		public float TempMorn { get; set; }

	}

	public class WeatherObject : BaseObject
	{

		public CityObject City { get; private set; }
		public int Id { get; set; }
		public string Main { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
		public WeatherMainInfo MainInfo { get; set; }
		public DayInfo DayInfo { get; set; }

		public WeatherObject(CityObject city) : base() {
			this.City = city;
		}

	}

}

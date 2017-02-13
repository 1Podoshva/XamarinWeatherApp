using System;
using System.Collections.Generic;
namespace WeatherLibrary
{
	public interface IDataService
	{
		List<CityEntity> Cities();
		void Insert(CityEntity city);
		void Update(CityEntity city);
		void Delete(CityEntity city);
		int CountOfCities();
	}
}

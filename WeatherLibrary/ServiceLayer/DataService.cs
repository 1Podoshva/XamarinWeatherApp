using System;
using System.Collections.Generic;
using MvvmCross.Plugins.Sqlite;
using SQLite;
using System.Xml.Linq;
using System.Linq;

namespace WeatherLibrary
{
	public class DataService : IDataService
	{

		//Private
		//

		private static string dataBaseName = "WeatherDataBase";
		private readonly IMvxSqliteConnectionFactory _sqliteConnectionFactory;
		private SQLiteConnection _connection;

		//Init
		//

		public DataService(IMvxSqliteConnectionFactory sqliteConnection) {
			_sqliteConnectionFactory = sqliteConnection;
			this.createDatabase();
		}

		#region PrivateMethods

		void createDatabase() {
			_connection = _sqliteConnectionFactory.GetConnection(dataBaseName);
			_connection.CreateTable<CityEntity>();
			_connection.Table<CityEntity>().OrderBy(x => x.Name).ToList();
		}

		#endregion

		#region IDataService

		public List<CityEntity> Cities() {
			return _connection.Table<CityEntity>().OrderBy(x => x.Name).ToList();
		}

		public int CountOfCities() {
			return _connection.Table<CityEntity>().Count();
		}

		public void Delete(CityEntity city) {
			_connection.Delete(city);
		}

		public void Insert(CityEntity city) {
			_connection.Insert(city);
		}

		public void Update(CityEntity city) {
			_connection.Update(city);
		}

		#endregion
	}
}

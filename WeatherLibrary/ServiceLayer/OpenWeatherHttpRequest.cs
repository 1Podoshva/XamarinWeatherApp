using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherLibrary
{
	public class OpenWeatherHttpRequest : IOpenWeatherHttpRequest
	{

		#region Property

		// Private property

		private static OpenWeatherHttpRequest _instance;

		private static HttpWebRequest _wepRequest;

		private static string _urlCurrentWeatherString = "http://api.openweathermap.org/data/2.5/weather";
		private static string _urlForecastWeatherString = "http://api.openweathermap.org/data/2.5/forecast/daily";

		// Public property

		public static string APIIDKey = "c529f8da9eb8c803bd18750875d165dc";

		public static OpenWeatherHttpRequest Instance
		{

			get {

				if (_instance == null) {
					_instance = new OpenWeatherHttpRequest();
				}

				return _instance;

			}

		}

		#endregion

		#region Init

		public OpenWeatherHttpRequest() {

		}

		#endregion

		#region IOpenWeatherHttpRequest

		public void GetWeatherWebRequests(CityObject city, Action<WeatherObject, WebException> eventHandler) {
			string urlRequestString = this.getUrlWeatherString(city, _urlCurrentWeatherString);

			if (urlRequestString != null) {

				_wepRequest = WebRequest.CreateHttp(urlRequestString);
				_wepRequest.ContentType = "application/json";
				_wepRequest.Method = "GET";

				sendRequest((HttpWebResponse responce, WebException e) => {
					httpCurentWeatherWepResponceEventHandler(responce, e, eventHandler);
				});

			}
			else {

				eventHandler(null, new WebException("City parametrs is null"));

			}
		}

		public void GetForecastWeatherWebRequests(CityObject city, Action<List<WeatherObject>, WebException> eventHandler) {

			string urlRequestString = this.getUrlWeatherString(city, _urlForecastWeatherString);

			if (urlRequestString != null) {

				_wepRequest = WebRequest.CreateHttp(urlRequestString);
				_wepRequest.ContentType = "application/json";
				_wepRequest.Method = "GET";

				sendRequest((HttpWebResponse responce, WebException e) => {
					httpForecastWeatherWepResponceEventHandler(responce, e, eventHandler);
				});

			}
			else {

				eventHandler(null, new WebException("City parametrs is null"));

			}

		}

		#endregion

		#region private HttpRequest

		private static void httpCurentWeatherWepResponceEventHandler(HttpWebResponse responce, WebException e, Action<WeatherObject, WebException> eventHandler) {

			if (responce != null) {

				if (responce.StatusCode != HttpStatusCode.OK) {

					System.Diagnostics.Debug.WriteLine("-- Error get weather staus description: {0} --", responce.StatusDescription);

				}

				else {

					System.Diagnostics.Debug.WriteLine("-- Get weather staus description: {0} --", responce.StatusDescription);

					StreamReader streamReader = new StreamReader(responce.GetResponseStream());

					string content = streamReader.ReadToEnd();

					if (string.IsNullOrWhiteSpace(content)) {

						System.Diagnostics.Debug.WriteLine("-- Response json contained empty body --");

					}
					else {

						System.Diagnostics.Debug.WriteLine("-- Response json contained body --");
						System.Diagnostics.Debug.WriteLine(content);
						eventHandler(parceCurrentWeatherJsonString(content), null);

					}

				}

			}
			else if (e != null) {
				eventHandler(null, e);
			}

		}

		private static void httpForecastWeatherWepResponceEventHandler(HttpWebResponse responce, WebException e, Action<List<WeatherObject>, WebException> eventHandler) {

			if (responce != null) {

				if (responce.StatusCode != HttpStatusCode.OK) {

					System.Diagnostics.Debug.WriteLine("-- Error get forecast weather staus description: {0} --", responce.StatusDescription);

				}

				else {

					System.Diagnostics.Debug.WriteLine("-- Get weather forecast staus description: {0} --", responce.StatusDescription);

					StreamReader streamReader = new StreamReader(responce.GetResponseStream());

					string content = streamReader.ReadToEnd();

					if (string.IsNullOrWhiteSpace(content)) {

						System.Diagnostics.Debug.WriteLine("-- Response json contained empty body --");

					}
					else {

						System.Diagnostics.Debug.WriteLine("-- Response json contained body --");
						System.Diagnostics.Debug.WriteLine(content);
						eventHandler(parceForecastWeatherJsonString(content), null);

					}

				}

			}
			else if (e != null) {
				eventHandler(null, e);
			}

		}

		private async static void sendRequest(Action<HttpWebResponse, WebException> responceEventHandler) {

			try {

				HttpWebResponse responce = await _wepRequest.GetResponseAsync() as HttpWebResponse;

				if (responceEventHandler != null)
					responceEventHandler(responce, null);

			}
			catch (WebException e) {

				System.Diagnostics.Debug.WriteLine("-- Errot send web request exception: {0} --", e.Message);

				if (responceEventHandler != null)
					responceEventHandler(null, e);

			}


		}

		private string getUrlWeatherString(CityObject city, string urlRequestString) {

			if ((city.Coordinates.Latitude != null) && (city.Coordinates.Longitude != null))
				return string.Format(urlRequestString + "?lat={0}&lon={1}&APPID={2}", city.Coordinates.Latitude, city.Coordinates.Longitude, APIIDKey);

			else if (city.Id != null)
				return string.Format(urlRequestString + "?id={0}&APPID={1}", city.Id, APIIDKey);

			else if (city.Name != null)
				return string.Format(urlRequestString + "?q={0}&APPID={1}", city.Name, APIIDKey);

			return null;

		}

		#endregion

		#region parceJSONString

		private static List<WeatherObject> parceForecastWeatherJsonString(string jsonContentString) {

			List<WeatherObject> forecast = new List<WeatherObject>();

			try {

				JObject obj = JObject.Parse(jsonContentString);

				JObject cityJson = (JObject) obj["city"];
				CityObject city = parceCity(cityJson);

				JArray weatherList = (Newtonsoft.Json.Linq.JArray) obj["list"];

				foreach (JObject weatherJson in weatherList) {

					WeatherObject weatherObj = parceWeather(city, weatherJson);
					weatherObj = parceForecastMainWeather(weatherObj, weatherJson);

					forecast.Add(weatherObj);
				}

				return forecast;

			}

			catch (JsonReaderException e) {
				System.Diagnostics.Debug.WriteLine("-- Error parce json: {0} --", e.Message);
			}

			return null;

		}

		private static WeatherObject parceCurrentWeatherJsonString(string jsonContentString) {

			try {

				JObject obj = JObject.Parse(jsonContentString);
				CityObject city = parceCity(obj);
				WeatherObject weather = parceWeather(city, obj);

				weather = parceCurrentMainInfoWeather(weather, (JObject) obj["main"]);
				weather = parceWindWeather(weather, (JObject) obj["wind"]);

				return weather;

			}
			catch (JsonReaderException e) {
				System.Diagnostics.Debug.WriteLine("-- Error parce json: {0} --", e.Message);

			}

			return null;
		}

		private static CityObject parceCity(JObject obj) {

			string cityID;

			try {
				cityID = (string) obj["id"];
			}
			catch (NullReferenceException) {
				cityID = (string) obj["geoname_id"];
			}

			string cityName = (string) obj["name"];

			JObject coord;
			string cityLat;
			string cityLon;

			try {
				coord = (JObject) obj["coord"];
				cityLat = (string) coord["lat"];
				cityLon = (string) coord["lon"];
			}
			catch (NullReferenceException) {
				cityLat = (string) obj["lat"];
				cityLon = (string) obj["lon"];
			}



			return new CityObject(cityID, cityName, new CityCoordinate(cityLat, cityLon));

		}

		private static WeatherObject parceWeather(CityObject city, JObject obj) {

			WeatherObject weather = new WeatherObject(city);

			var weatherJson = obj["weather"][0];

			weather.Id = (int) weatherJson["id"];
			weather.Main = (string) weatherJson["main"];
			weather.Description = (string) weatherJson["description"];
			weather.Icon = (string) weatherJson["icon"];

			return weather;

		}

		private static WeatherObject parceCurrentMainInfoWeather(WeatherObject weather, JObject obj) {

			var weatherJson = obj;

			WeatherMainInfo mainInfo = new WeatherMainInfo();

			mainInfo.Temp = (float) weatherJson["temp"];
			mainInfo.Pressure = (float) weatherJson["pressure"];
			mainInfo.Humidity = (float) weatherJson["humidity"];
			mainInfo.Temp_min = (float) weatherJson["temp_min"];
			mainInfo.Temp_max = (float) weatherJson["temp_max"];

			weather.MainInfo = mainInfo;

			return weather;

		}

		private static WeatherObject parceWindWeather(WeatherObject weather, JObject obj) {

			Wind windInfo = new Wind();

			windInfo.Speed = (float) obj["speed"];
			windInfo.Deg = (float) obj["deg"];

			weather.MainInfo.Wind = windInfo;

			return weather;

		}

		private static WeatherObject parceForecastMainWeather(WeatherObject weather, JObject obj) {

			var weatherJson = obj;

			WeatherMainInfo mainInfo = new WeatherMainInfo();

			mainInfo.Pressure = (float) weatherJson["pressure"];
			mainInfo.Humidity = (float) weatherJson["humidity"];

			weatherJson = (JObject) obj["temp"];

			mainInfo.Temp = (float) weatherJson["day"];
			mainInfo.Temp_min = (float) weatherJson["min"];
			mainInfo.Temp_max = (float) weatherJson["max"];

			DayInfo dayInfo = new DayInfo();
			dayInfo.Temp = (float) weatherJson["day"];
			dayInfo.TempNight = (float) weatherJson["night"];
			dayInfo.TempEve = (float) weatherJson["eve"];
			dayInfo.TempMorn = (float) weatherJson["morn"];

			weather.MainInfo = mainInfo;
			weather.DayInfo = dayInfo;

			return parceWindWeather(weather, obj);

		}

		#endregion


	}
}

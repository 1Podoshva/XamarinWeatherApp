using System;
using System.Net;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace WeatherLibrary
{
	public class App : MvxApplication
	{

		public App() : base() {

			//CityObject city = new CityObject(null, "Minsk", new CityCoordinate(null, null));

			//Mvx.RegisterType<WeatherMainModel>(() => new WeatherMainModel(city));
			//Mvx.RegisterType<WeatherForecastModel>(() => new WeatherForecastModel(city));

			//Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<WeatherForecastViewModel>());

			Mvx.RegisterType<IDataService, DataService>();
			Mvx.RegisterType<WeatherPageModel>(() => new WeatherPageModel());
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<WeatherPagedViewModel>());

		}

		//public override void Initialize() {
		//	base.Initialize();
		//	//Start
		//	RegisterAppStart<LocationViewModel>();
		//}
	}

}

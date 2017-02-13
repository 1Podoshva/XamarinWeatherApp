using System;
using System.Net;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace WeatherLibrary
{
	public class App : MvxApplication
	{

		public App() : base() {

			Mvx.RegisterType<IDataService, DataService>();
			Mvx.RegisterType<WeatherPageModel>(() => new WeatherPageModel(Mvx.Resolve<IDataService>()));
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<WeatherPagedViewModel>());

		}

	}

}

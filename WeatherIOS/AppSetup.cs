using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using WeatherLibrary;
using UIKit;

namespace WeatherIOS
{
	public class AppSetup : MvxIosSetup
	{
		public AppSetup(IMvxApplicationDelegate applicationDelegate, MvxIosViewPresenter presenter) : base(applicationDelegate, presenter) {

		}

		public AppSetup(IMvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window) {

		}

		protected override IMvxApplication CreateApp() {
			return new App();
		}
	}
}

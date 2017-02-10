using System;
using MvvmCross.Plugins.Location;
using MvvmCross.Platform;
namespace WeatherLibrary
{
	public class LocationManager
	{
		private static LocationManager _instance;
		private IMvxLocationWatcher _locationWatcher;

		private LocationManager() {
			_locationWatcher = Mvx.Resolve<IMvxLocationWatcher>();
		}

		public LocationManager Instance(IMvxLocationWatcher locationWatcher) {

			if (_instance == null) {
				_instance = new LocationManager();
			}

			return _instance;

		}




	}
}
using System;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Core.ViewModels;

namespace WeatherLibrary
{
	public class LocationViewModel : MvxViewModel
	{
		private readonly IMvxLocationWatcher _watcher;

		public LocationViewModel(IMvxLocationWatcher watcher) {
			_watcher = watcher;
			_watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
		}

		private void OnLocation(MvxGeoLocation location) {
			System.Diagnostics.Debug.WriteLine("lat: {0}", location.Coordinates.Latitude);
			System.Diagnostics.Debug.WriteLine("long: {0}", location.Coordinates.Longitude);
		}

		private void OnError(MvxLocationError error) {
			Mvx.Error("Seen location error {0}", error.Code);
		}
	}
}

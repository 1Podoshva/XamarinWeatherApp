using System;
using MvvmCross.Plugins.Location;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;

namespace WeatherLibrary
{
	interface ILocationManager
	{
		void OnPermissionChanged(Action<MvxLocationPermission> valueEvent);
		void StartGetCurrentLocation(MvxLocationOptions options, Action<MvxGeoLocation> locationHandler, Action<MvxLocationError> errorHandler);
		void Stop();
	}

	public class LocationManager : ILocationManager
	{

		#region Private

		private static LocationManager _instance;
		public static IMvxLocationWatcher _locationWatcher;
		private static MvxLocationOptions _locationOptions;

		private LocationManager() {
			_locationWatcher = Mvx.Resolve<IMvxLocationWatcher>();
			_locationOptions = new MvxLocationOptions();
			_locationOptions.TrackingMode = MvxLocationTrackingMode.Foreground;
		}

		#endregion

		#region Instance

		public static LocationManager Instance
		{

			get {
				if (_instance == null) {
					_instance = new LocationManager();
				}

				return _instance;
			}

		}

		#endregion

		#region ILocationManager

		public void StartGetCurrentLocation(MvxLocationOptions options, Action<MvxGeoLocation> locationHandler, Action<MvxLocationError> errorHandler) {

			if (_locationWatcher != null)
				_locationWatcher.Start(options ?? _locationOptions, locationHandler, errorHandler);

		}

		public void Stop() {

			if (_locationWatcher != null)
				_locationWatcher.Stop();

		}

		public void OnPermissionChanged(Action<MvxLocationPermission> valueEvent) {

			_locationWatcher.OnPermissionChanged += (object sender, MvxValueEventArgs<MvxLocationPermission> e) => {
				valueEvent(e.Value);
			};

		}

		#endregion

	}
}
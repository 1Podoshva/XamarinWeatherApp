using System;
using UIKit;
using MvvmCross.iOS.Views;
using WeatherLibrary;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Plugins.Location.iOS;

namespace WeatherIOS
{
	public partial class LocationViewController : MvxViewController<LocationViewModel>

	{

		public LocationViewController() : base("LocationViewController", null) {
		}

		public override void ViewDidLoad() {
			base.ViewDidLoad();
			MvxIosLocationWatcher loc = new MvxIosLocationWatcher();

			var set = this.CreateBindingSet<LocationViewController, LocationViewModel>();
			set.Apply();
		}

		public override void DidReceiveMemoryWarning() {
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


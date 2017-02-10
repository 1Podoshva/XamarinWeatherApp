using System;

using UIKit;
using MvvmCross.iOS.Views;
using WeatherLibrary;
using MvvmCross.Binding.BindingContext;

namespace WeatherIOS
{
	public partial class StartPageViewController : MvxViewController<StartPageViewModel>
	{
		public StartPageViewController() : base("StartPageViewController", null) {
		}

		public override void ViewDidLoad() {

			base.ViewDidLoad();

			var set = this.CreateBindingSet<StartPageViewController, StartPageViewModel>();
			set.Apply();

			this.ViewModel.ShowCommand.Execute();

		}

		public override void DidReceiveMemoryWarning() {
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


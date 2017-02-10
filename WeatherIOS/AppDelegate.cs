using Foundation;
using UIKit;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;

namespace WeatherIOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window { get; set; }
		public static UIStoryboard Storyboard = UIStoryboard.FromName("Main", null);

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions) {

			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			//var presenter = new MvxIosViewPresenter(this, Window);
			//var setup = new AppSetup(this, presenter);

			var setup = new AppSetup(this, Window);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			Window.MakeKeyAndVisible();

			return true;
		}



	}
}


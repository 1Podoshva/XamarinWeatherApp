using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using WeatherLibrary;
using UIKit;

namespace WeatherIOS
{
	public class WeatherPageViewController : MvxPageViewController<WeatherPagedViewModel>
	{

		//Public
		public new WeatherPagedViewModel ViewModel
		{
			get { return (WeatherPagedViewModel) base.ViewModel; }
			set { base.ViewModel = value; }

		}

		public WeatherPageViewController() : base(UIKit.UIPageViewControllerTransitionStyle.Scroll, UIKit.UIPageViewControllerNavigationOrientation.Horizontal, UIKit.UIPageViewControllerSpineLocation.None) {

		}

		public override void ViewDidLoad() {
			base.ViewDidLoad();

			UIImageView imageView = new UIImageView(new UIImage("MainWeather_bgImage.png"));
			imageView.Frame = UIScreen.MainScreen.Bounds;

			this.View.Frame = UIScreen.MainScreen.Bounds;
			this.View.InsertSubview(imageView, 0);

			this.NavigationController.NavigationBarHidden = true;
			var set = this.CreateBindingSet<WeatherPageViewController, WeatherPagedViewModel>();
			set.Apply();

		}

	}
}

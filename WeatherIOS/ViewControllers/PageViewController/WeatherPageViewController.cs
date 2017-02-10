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

			UIButton toCityButton = new UIButton(UIButtonType.Custom);

			float size = 30;
			toCityButton.Frame = new CoreGraphics.CGRect(View.Frame.Size.Width - size * 1.3, size, size, size);
			toCityButton.SetImage(new UIImage("Plus-100.png"), UIControlState.Normal);
			View.Add(toCityButton);

			this.NavigationController.NavigationBarHidden = true;

			var set = this.CreateBindingSet<WeatherPageViewController, WeatherPagedViewModel>();
			set.Bind(toCityButton).To(vm => vm.ShowCityDataServiceCommand);
			set.Apply();

		}

	}
}

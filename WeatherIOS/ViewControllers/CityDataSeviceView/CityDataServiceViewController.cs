using System;

using UIKit;
using WeatherLibrary;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace WeatherIOS
{
	public partial class CityDataServiceViewController : MvxViewController
	{

		//Public
		//
		public new CityDataServiceViewModel ViewModel
		{
			get { return (CityDataServiceViewModel) base.ViewModel; }
			set { base.ViewModel = value; }

		}
		public CityDataServiceViewController() : base("CityDataServiceViewController", null) {

		}

		public CityDataServiceViewController(IntPtr handle) : base(handle) {

		}

		public override void ViewDidLoad() {
			base.ViewDidLoad();

			this.NavigationController.SetNavigationBarHidden(false, true);

			var source = new MvxStandardTableViewSource(TableView);
			TableView.RowHeight = 100.0f;
			TableView.Source = source;

			var set = this.CreateBindingSet<CityDataServiceViewController, CityDataServiceViewModel>();
			set.Bind(source).To((CityDataServiceViewModel vm) => vm.Cites);
			set.Apply();

			TableView.ReloadData();

		}

		public override void ViewWillDisappear(bool animated) {
			base.ViewWillDisappear(animated);
			this.NavigationController.SetNavigationBarHidden(true, true);
		}

		public override void DidReceiveMemoryWarning() {
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}


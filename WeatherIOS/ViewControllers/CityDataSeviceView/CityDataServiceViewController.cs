using System;

using UIKit;
using WeatherLibrary;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Foundation;

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

		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);
			this.NavigationController.SetNavigationBarHidden(false, true);
			this.NavigationController.NavigationBar.BarTintColor = new UIColor(20f / 255f, 37f / 255f, 47f / 255f, 1);
			this.NavigationController.NavigationBar.TintColor = UIColor.White;
		}

		public override void ViewDidLoad() {
			base.ViewDidLoad();

			this.View.BackgroundColor = new UIColor(20f / 255f, 37f / 255f, 47f / 255f, 1);
			this.TableView.BackgroundColor = new UIColor(20f / 255f, 37f / 255f, 47f / 255f, 1);
			this.TextField.BackgroundColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 0.1f);

			this.EdgesForExtendedLayout = UIRectEdge.None;
			this.bindingViews();

		}

		public override void ViewWillDisappear(bool animated) {
			base.ViewWillDisappear(animated);
			this.NavigationController.SetNavigationBarHidden(true, true);
		}

		public override void DidReceiveMemoryWarning() {
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void bindingViews() {
			var source = new CityTableViewDataSource(TableView, CityTableViewCell.Key, CityTableViewCell.Key, NSBundle.MainBundle);
			TableView.RowHeight = 40.0f;
			TableView.Source = source;

			source.removeItemEventHandler += (NSIndexPath indexPath) => {
				ViewModel.RemoveCity.Execute(indexPath.Row);
			};

			source.updateItemEventHandler += (NSIndexPath indexPath) => {
				ViewModel.UpdateCity.Execute(indexPath.Row);
			};

			var set = this.CreateBindingSet<CityDataServiceViewController, CityDataServiceViewModel>();
			set.Bind(source).To((CityDataServiceViewModel vm) => vm.Cites).Apply();
			set.Apply();

			TableView.ReloadData();

			set.Bind(TextField).To((CityDataServiceViewModel vm) => vm.CreateCityViewModel.Name).Apply();

			this.CreateBinding(TextField).For(textField => textField.Placeholder).To((CityDataServiceViewModel vm) => vm.CreateCityViewModel.PlaceHolder).Apply();

			TextField.ShouldReturn += delegate {
				ViewModel.InsertCity.Execute(null);
				TextField.ResignFirstResponder();
				return true;
			};

		}

	}
}


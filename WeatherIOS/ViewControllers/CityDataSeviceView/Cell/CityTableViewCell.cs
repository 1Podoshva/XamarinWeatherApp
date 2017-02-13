using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using WeatherLibrary;

namespace WeatherIOS
{
	public partial class CityTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("CityTableViewCell");
		public static readonly UINib Nib = UINib.FromName("CityTableViewCell", NSBundle.MainBundle);

		static CityTableViewCell() {
			Nib = UINib.FromName("CityTableViewCell", NSBundle.MainBundle);
		}

		public override void AwakeFromNib() {
			base.AwakeFromNib();
			this.BackgroundColor = UIColor.Clear;
			foreach (UIView view in Subviews) {
				view.BackgroundColor = UIColor.Clear;
			}
		}

		protected CityTableViewCell(IntPtr handle) : base(handle) {

			this.DelayBind(() => {

				var set = this.CreateBindingSet<CityTableViewCell, CityEntity>();
				set.Bind(TextField).To((CityEntity vm) => vm.Name).Apply();

			});

		}

	}
}

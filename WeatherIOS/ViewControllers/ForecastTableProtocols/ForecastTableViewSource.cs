using System;
using MvvmCross.Binding.iOS.Views;
namespace WeatherIOS
{
	public class ForecastTableViewSource : MvxSimpleTableViewSource
	{
		#region Init

		public ForecastTableViewSource(IntPtr handle) : base(handle) {
		}

		public ForecastTableViewSource(UIKit.UITableView tableView, string nibName, string cellIdentifier, Foundation.NSBundle bundle) : base(tableView, nibName, cellIdentifier, bundle) {
		}

		public ForecastTableViewSource(UIKit.UITableView tableView, Type cellType, string cellIdentifier) : base(tableView, cellType, cellIdentifier) {
		}

		#endregion


		protected override UIKit.UITableViewCell GetOrCreateCellFor(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath, object item) {
			ForecastTableViewCell cell = base.GetOrCreateCellFor(tableView, indexPath, item) as ForecastTableViewCell;

			if (cell != null) {

				cell.SetDateByAddingDays(indexPath.Row + 1);

			}

			return cell;


		}

	}
}

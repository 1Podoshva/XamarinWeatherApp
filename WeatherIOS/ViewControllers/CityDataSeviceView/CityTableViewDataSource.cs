using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace WeatherIOS
{
	public class CityTableViewDataSource : MvxSimpleTableViewSource
	{

		public event Action<NSIndexPath> removeItemEventHandler;
		public event Action<NSIndexPath> updateItemEventHandler;

		#region Init

		public CityTableViewDataSource(IntPtr handle) : base(handle) {

		}

		public CityTableViewDataSource(UIKit.UITableView tableView, string nibName, string cellIdentifier, Foundation.NSBundle bundle) : base(tableView, nibName, cellIdentifier, bundle) {
			RemoveAnimation = UITableViewRowAnimation.Left;
		}

		public CityTableViewDataSource(UIKit.UITableView tableView, Type cellType, string cellIdentifier) : base(tableView, cellType, cellIdentifier) {
		}

		#endregion

		protected override UIKit.UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item) {
			CityTableViewCell cell = base.GetOrCreateCellFor(tableView, indexPath, item) as CityTableViewCell;

			if (cell != null) {

				cell.TextField.ShouldReturn += delegate {

					if (cell.TextField.Text != "")
						if (updateItemEventHandler != null)
							updateItemEventHandler(indexPath);

					cell.TextField.ResignFirstResponder();
					cell.TextField.Text = "";

					return true;
				};

				if (indexPath.Row % 2 == 0) {
					cell.BackgroundColor = new UIColor(32f / 255f, 53f / 255f, 70f / 255f, 1);
				}
				else {
					cell.BackgroundColor = new UIColor(28f / 255f, 45f / 255f, 60f / 255f, 1);
				}

			}

			return cell;

		}

		public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath) {
			return true;
		}


		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath) {

			if (editingStyle == UITableViewCellEditingStyle.Delete) {

				if (removeItemEventHandler != null)
					removeItemEventHandler(indexPath);

			}

		}
	}
}

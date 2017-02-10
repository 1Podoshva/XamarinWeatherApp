using System;
using UIKit;
namespace WeatherIOS
{
	public class ForecastTableViewDelegate : UITableViewDelegate
	{
		public event Action DidEndScrolling;
		public event Action<UIScrollView> DidDraggingEnded;
		public event Action<UIScrollView> DidScrolling;

		public ForecastTableViewDelegate() {

		}

		public override void Scrolled(UIScrollView scrollView) {

			if (this.DidScrolling != null)
				this.DidScrolling(scrollView);

		}

		public override void DecelerationEnded(UIScrollView scrollView) {

			if (this.DidEndScrolling != null)
				this.DidEndScrolling();

		}

		public override void DraggingEnded(UIScrollView scrollView, bool willDecelerate) {

			if (this.DidEndScrolling != null)
				this.DidEndScrolling();

		}

	}
}

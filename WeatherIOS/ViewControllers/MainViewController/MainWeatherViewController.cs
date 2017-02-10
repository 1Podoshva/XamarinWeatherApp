using UIKit;
using MvvmCross.iOS.Views;
using WeatherLibrary;
using MvvmCross.Binding.BindingContext;
using Foundation;
using System;
using CoreGraphics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace WeatherIOS
{
	public partial class MainWeatherViewController : MvxViewController<WeatherMainPageViewModel>
	{

		#region Property

		//Private

		private static MainViewModelValueConverter mainViewModelValueConverter = new MainViewModelValueConverter();
		private UIPanGestureRecognizer panGestureRecognizer;
		private ForecastTableViewDelegate tableViewDelegate = new ForecastTableViewDelegate();

		#endregion

		#region Init

		public MainWeatherViewController() : base("MainWeatherViewController", null) {

		}

		public MainWeatherViewController(IntPtr handle) : base(handle) {

		}

		#endregion

		#region  LifeCycle

		public override void ViewDidLoad() {

			base.ViewDidLoad();

			this.createViewBinding();
			this.createUIGestures();

			this.ViewModel.DidEndUpadateWeather += ViewModel_DidEndUpadateWeather;
			this.ViewModel.DidStartUpadateWeather += ViewModel_DidStartUpadateWeather;

			this.ViewModel.Update.Execute(null);
			tableViewDelegate.DidScrolling += ForecastTableViewDelegate_DidScrolling;
			tableViewDelegate.DidEndScrolling += ForecastTableViewDelegate_DidEndScrolling;
			tableViewDelegate.DidDraggingEnded += ForecastTableViewDelegate_DidDraggingEnded;

			this.TableView.Delegate = tableViewDelegate;
		}

		public override void DidReceiveMemoryWarning() {
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void ViewModel_DidEndUpadateWeather() {
			ActivityIndicator.StopAnimating();
			ActivityIndicator.Hidden = true;
		}

		void ViewModel_DidStartUpadateWeather() {
			ActivityIndicator.Hidden = false;
			ActivityIndicator.StartAnimating();
		}

		#endregion

		#region CreateMetods

		private void createViewBinding() {

			this.CreateBinding(CityLabel).To((WeatherMainPageViewModel vm) => vm.City).Apply();
			this.CreateBinding(MainLabel).To((WeatherMainPageViewModel vm) => vm.Main).Apply();

			var tempSet = this.CreateBindingSet<MainWeatherViewController, WeatherMainPageViewModel>();
			tempSet.Bind(TempLabel).To((WeatherMainPageViewModel vm) => vm.Temperature).WithConversion(mainViewModelValueConverter, new ConverterValueContext(ViewModel.TemperatureFormat, PropertyName.Temperature));
			tempSet.Apply();

			tempSet.Bind(WindLabel).To((WeatherMainPageViewModel vm) => vm.WindSpeed).WithConversion(mainViewModelValueConverter, new ConverterValueContext(ViewModel.TemperatureFormat, PropertyName.WindSpeed));
			tempSet.Apply();

			tempSet.Bind(HumidityLabel).To((WeatherMainPageViewModel vm) => vm.Humidity).WithConversion(mainViewModelValueConverter, new ConverterValueContext(ViewModel.TemperatureFormat, PropertyName.Humidity));
			tempSet.Apply();

			NSDate date = new NSDate();
			NSDateFormatter dateFormat = new NSDateFormatter();

			dateFormat.DateFormat = "EEEE d";
			this.DayLabel.Text = dateFormat.ToString(date);

			dateFormat.DateFormat = "MMMM yyyy";
			this.MonthLabel.Text = dateFormat.ToString(date);

			this.createTableViewBinding();

		}

		void createTableViewBinding() {

			var source = new ForecastTableViewSource(TableView, ForecastTableViewCell.Key, ForecastTableViewCell.Key, NSBundle.MainBundle);
			TableView.RowHeight = UITableView.AutomaticDimension;
			TableView.EstimatedRowHeight = 153.0f;
			TableView.Source = source;

			var set = this.CreateBindingSet<MainWeatherViewController, WeatherForecastViewModel>();
			set.Bind(source).To((WeatherForecastViewModel vm) => vm.Forecast);
			set.Apply();

			TableView.ReloadData();

		}

		void createUIGestures() {
			this.panGestureRecognizer = new UIPanGestureRecognizer(panGestureRecognizerEventHandler);
			this.panGestureRecognizer.WeakDelegate = this;
			ContentView.AddGestureRecognizer(this.panGestureRecognizer);
		}

		[Export("gestureRecognizer:shouldRecognizeSimultaneouslyWithGestureRecognizer:")]
		public Boolean ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer) {

			CGPoint point = panGestureRecognizer.VelocityInView(ContentView);

			return Math.Abs(point.Y) < Math.Abs(point.X);
		}

		#endregion

		#region UIGestureHandlers

		private void panGestureRecognizerEventHandler(UIPanGestureRecognizer gesture) {


			switch (gesture.State) {

				case UIGestureRecognizerState.Began: {

						break;
					}

				case UIGestureRecognizerState.Changed: {
						panGestureRecognizerHandlerChanged(gesture);
						break;
					}

				case UIGestureRecognizerState.Ended: {
						panGestureRecognizerHandlerEnd(gesture);
						break;
					}

				case UIGestureRecognizerState.Cancelled: {
						panGestureRecognizerHandlerEnd(gesture);
						break;
					}

				default:
					break;

			}


		}

		private void panGestureRecognizerHandlerChanged(UIPanGestureRecognizer gesture) {

			CGPoint translation = gesture.TranslationInView(ContentView);

			ContentView_LayoutCenterY.Constant += translation.Y;
			gesture.SetTranslation(new CGPoint(0.0, 0.0), ContentView);


		}

		private void panGestureRecognizerHandlerEnd(UIPanGestureRecognizer gesture) {

			if (ContentView_LayoutCenterY.Constant >= 50.0)
				this.ViewModel.Update.Execute(null);

			if (ContentView_LayoutCenterY.Constant <= -150.0)
				this.showTableView(true);
			else
				this.showTableView(false);

			gesture.SetTranslation(new CGPoint(0.0, 0.0), ContentView);

		}

		#endregion

		#region Animations

		private void showTableView(bool show) {

			if (show == true) {

				ContentView_LayoutCenterY.Constant = -(ContentView.Frame.Size.Height);

				UIView.Animate(0.3, 0, UIViewAnimationOptions.CurveEaseInOut, () => {

					View.LayoutIfNeeded();

				}, () => { });

			}

			else {

				ContentView_LayoutCenterY.Constant = 0;

				UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseInOut, () => {

					View.LayoutIfNeeded();

				}, () => { });

			}

		}

		#endregion

		#region ForecastTableViewDelegateActions

		void ForecastTableViewDelegate_DidScrolling(UIScrollView scrollView) {
			if (scrollView.ContentOffset.Y <= -40)
				this.showTableView(false);
		}

		void ForecastTableViewDelegate_DidDraggingEnded(UIScrollView scrollView) {

		}

		void ForecastTableViewDelegate_DidEndScrolling() {

		}

		#endregion
	}




}


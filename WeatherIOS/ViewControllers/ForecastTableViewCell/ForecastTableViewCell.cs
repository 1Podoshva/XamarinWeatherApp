using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using WeatherLibrary;

namespace WeatherIOS
{
	public partial class ForecastTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("ForecastTableViewCell");
		public static readonly UINib Nib = UINib.FromName("ForecastTableViewCell", NSBundle.MainBundle);
		private static ForecastTableViewCellValueConverter valueConverter = new ForecastTableViewCellValueConverter();


		static ForecastTableViewCell() {
			Nib = UINib.FromName("ForecastTableViewCell", NSBundle.MainBundle);
		}

		public override void AwakeFromNib() {
			base.AwakeFromNib();

			foreach (UIView view in this.Subviews)
				view.BackgroundColor = UIColor.Clear;

			this.BackgroundColor = UIColor.Clear;

		}

		protected ForecastTableViewCell(IntPtr handle) : base(handle) {
			this.DelayBind(() => {

				var set = this.CreateBindingSet<ForecastTableViewCell, WeatherObject>();

				set.Bind(MainLabel).To((WeatherObject weather) => weather.Main).Apply();
				set.Bind(TempLabel).To((WeatherObject weather) => weather.DayInfo.Temp).WithConversion(valueConverter, new ConverterValueContext(TemperatureFormat.Celsius, PropertyName.Temperature));
				set.Apply();

				set.Bind(HumidityLabel).To((WeatherObject weather) => weather.MainInfo.Humidity).WithConversion(valueConverter, new ConverterValueContext(TemperatureFormat.Celsius, PropertyName.Humidity));
				set.Apply();

				set.Bind(WindSpeedLabel).To((WeatherObject weather) => weather.MainInfo.Wind.Speed).WithConversion(valueConverter, new ConverterValueContext(TemperatureFormat.Celsius, PropertyName.WindSpeed));
				set.Apply();

				set.Bind(DescriptionLabel).To((WeatherObject weather) => weather.Description).Apply();
				set.Apply();

			});
		}

		internal void SetDateByAddingDays(int days) {
			NSDate date = new NSDate();
			date = date.AddSeconds(60 * 60 * 24 * days);

			NSDateFormatter dateFormat = new NSDateFormatter();

			dateFormat.DateFormat = "EEEE d";
			DayNameLabel.Text = dateFormat.ToString(date);

		}
	}
}

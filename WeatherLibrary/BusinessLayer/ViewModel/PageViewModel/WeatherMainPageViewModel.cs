using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Location;

namespace WeatherLibrary
{
	public class WeatherMainPageViewModel : WeatherMainViewModel, IMvxPagedViewModel
	{

		public WeatherMainPageViewModel(WeatherMainModel model) : base(model) {
			_pagedViewId = model.CurrentWeather.City.Name;
		}

		private string _pagedViewId;

		public string PagedViewId
		{
			get {
				return _pagedViewId ?? "emptyID";
			}
		}
	}
}

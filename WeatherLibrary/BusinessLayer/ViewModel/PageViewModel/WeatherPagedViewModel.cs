using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using System.Windows.Input;
using MvvmCross.Plugins.Messenger;

namespace WeatherLibrary
{
	public class WeatherPagedViewModel : MvxViewModel, IMvxPageViewModel
	{

		//Private property
		//

		private WeatherPageModel _model;
		private WeatherMainPageViewModel _defaultViewModel;
		private MvxCommand _showCityDataServiceView;
		private IMvxLocationWatcher _watcher;
		private WeatherMainPageViewModel _currentLocationPageView;
		private IMvxMessenger _massager;
		private MvxSubscriptionToken _token;

		//Public property
		//

		public List<WeatherMainPageViewModel> ViewModels { get; private set; }
		public ICommand ShowCityDataServiceCommand
		{
			get {
				_showCityDataServiceView = _showCityDataServiceView ?? new MvxCommand(showCityDataServiceCommand);
				return _showCityDataServiceView;
			}
		}

		//Init
		//

		public WeatherPagedViewModel(WeatherPageModel model, IMvxLocationWatcher watcher, IMvxMessenger massager) {

			_massager = massager;
			_token = _massager.Subscribe<CitiesMassage>(OnUpdateCities);
			_watcher = watcher;
			_watcher.Start(new MvxLocationOptions(), locationEventHandleAction, errorEventHandleAction);
			_model = model;
			this.InitViewModels();

		}

		//Private methods
		//

		private void InitViewModels() {

			ViewModels = new List<WeatherMainPageViewModel>();
			foreach (WeatherMainModel mainModel in _model.MainModels) {
				ViewModels.Add(new WeatherMainPageViewModel(mainModel));
			}

			if (ViewModels.Count > 0)
				_defaultViewModel = ViewModels[0];
			else if (_currentLocationPageView != null)
				_defaultViewModel = _currentLocationPageView;
			else {
				_defaultViewModel = new WeatherMainPageViewModel(new WeatherMainModel(new CityObject(null, null, new CityCoordinate(null, null))));
			}

		}

		void showCityDataServiceCommand() {
			ShowViewModel<CityDataServiceViewModel>();
		}

		#region IMvxPageViewModel

		public IMvxPagedViewModel GetDefaultViewModel() {
			return _currentLocationPageView ?? _defaultViewModel;
		}

		public IMvxPagedViewModel GetNextViewModel(IMvxPagedViewModel currentViewModel) {

			int index = ViewModels.FindIndex((WeatherMainPageViewModel obj) => { return obj.PagedViewId.Equals(currentViewModel.PagedViewId); });

			if (index < ViewModels.Count - 1)
				return ViewModels[index + 1];

			return null;
		}

		public IMvxPagedViewModel GetPreviousViewModel(IMvxPagedViewModel currentViewModel) {

			int index = ViewModels.FindIndex((WeatherMainPageViewModel obj) => { return obj.PagedViewId.Equals(currentViewModel.PagedViewId); });

			if (index > 0)
				return ViewModels[index - 1];

			if (index == 0 && _currentLocationPageView != null)
				return _currentLocationPageView;

			return null;

		}

		#endregion


		void locationEventHandleAction(MvxGeoLocation location) {

			string lat = location.Coordinates.Latitude.ToString();
			string lon = location.Coordinates.Longitude.ToString();

			CityObject city = new CityObject(null, null, new CityCoordinate(lat, lon));
			WeatherMainModel pageModel = new WeatherMainModel(city);
			_currentLocationPageView = new WeatherMainPageViewModel(pageModel);

		}

		void errorEventHandleAction(MvxLocationError obj) {
			System.Diagnostics.Debug.WriteLine("-- Error get location: {} --", obj.Code);
			_currentLocationPageView = null;
		}

		void OnUpdateCities(CitiesMassage obj) {
			_model.UpdateMianModels();
			InitViewModels();
		}
	}
}

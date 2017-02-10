using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using System.Windows.Input;

namespace WeatherLibrary
{
	public class WeatherPagedViewModel : MvxViewModel, IMvxPageViewModel
	{

		//Private property
		//

		private WeatherPageModel _model;
		private WeatherMainPageViewModel _defaultViewModel;
		private MvxCommand _showCityDataServiceView;

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

		public WeatherPagedViewModel(WeatherPageModel model) {
			_model = model;
			this.InitViewModels();
			_defaultViewModel = ViewModels[0];
		}

		//Private methods
		//

		private void InitViewModels() {

			ViewModels = new List<WeatherMainPageViewModel>();
			foreach (WeatherMainModel mainModel in _model.MainModels) {
				ViewModels.Add(new WeatherMainPageViewModel(mainModel));
			}

		}

		void showCityDataServiceCommand() {
			ShowViewModel<CityDataServiceViewModel>();
		}

		#region IMvxPageViewModel

		public IMvxPagedViewModel GetDefaultViewModel() {
			return _defaultViewModel;
		}

		public IMvxPagedViewModel GetNextViewModel(IMvxPagedViewModel currentViewModel) {

			int index = ViewModels.FindIndex((WeatherMainPageViewModel obj) => { return obj.Equals(currentViewModel); });

			if (index < ViewModels.Count - 1)
				return ViewModels[index + 1];


			return null;
		}

		public IMvxPagedViewModel GetPreviousViewModel(IMvxPagedViewModel currentViewModel) {

			int index = ViewModels.FindIndex((WeatherMainPageViewModel obj) => { return obj.Equals(currentViewModel); });

			if (index > 0)
				return ViewModels[index - 1];

			return null;

		}

		#endregion


	}
}

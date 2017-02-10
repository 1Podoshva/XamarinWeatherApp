using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;

namespace WeatherLibrary
{
	public class WeatherPagedViewModel : MvxViewModel, IMvxPageViewModel
	{

		private WeatherPageModel _model;
		private WeatherMainPageViewModel _defaultViewModel;

		public List<WeatherMainPageViewModel> ViewModels { get; private set; }

		public WeatherPagedViewModel(WeatherPageModel model) {
			_model = model;
			this.InitViewModels();
			_defaultViewModel = ViewModels[0];
		}

		private void InitViewModels() {

			ViewModels = new List<WeatherMainPageViewModel>();
			foreach (WeatherMainModel mainModel in _model.MainModels) {
				ViewModels.Add(new WeatherMainPageViewModel(mainModel));
			}

		}

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


	}
}

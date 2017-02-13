using System;
using MvvmCross.Core.ViewModels;
namespace WeatherLibrary
{
	public class CreateCityViewModel : MvxViewModel
	{
		private string _name;
		public string Name
		{
			get {
				return _name;
			}

			set {
				_name = value; RaisePropertyChanged(() => Name);
			}

		}

		private string _placeHolder;
		public string PlaceHolder
		{
			get {
				return _placeHolder;
			}

			set {
				_placeHolder = value; RaisePropertyChanged(() => PlaceHolder);
			}

		}

		public CreateCityViewModel() {
			PlaceHolder = "Add new city...";
		}
	}
}

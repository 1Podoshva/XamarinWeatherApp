using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace WeatherLibrary
{
	public class CityDataServiceViewModel : MvxViewModel
	{
		#region Property


		private IDataService _dataService;
		private IMvxMessenger _massager;

		private CreateCityViewModel _createCityViewModel;
		private List<CityEntity> _cites;

		private MvxCommand _insertCity;
		private MvxCommand<int> _removeCity;
		private MvxCommand<int> _updateCity;

		public List<CityEntity> Cites
		{
			get { return _cites; }
			set {
				_cites = value;
				RaisePropertyChanged(() => Cites);
				_massager.Publish(new CitiesMassage(this));
			}
		}

		public CreateCityViewModel CreateCityViewModel
		{
			get { return _createCityViewModel; }
			set { _createCityViewModel = value; RaisePropertyChanged(() => CreateCityViewModel); }
		}

		public ICommand InsertCity
		{
			get {
				_insertCity = _insertCity ?? new MvxCommand(insertCity);
				return _insertCity;
			}
		}

		public ICommand RemoveCity
		{
			get {
				_removeCity = _removeCity ?? new MvxCommand<int>((obj) => { remvoeCity(obj); });
				return _removeCity;
			}
		}

		public ICommand UpdateCity
		{
			get {
				_updateCity = _updateCity ?? new MvxCommand<int>((obj) => { updateCity(obj); });
				return _updateCity;
			}
		}

		#endregion

		public CityDataServiceViewModel(IDataService dataService, IMvxMessenger massager) {
			_massager = massager;
			_dataService = dataService;
			CreateCityViewModel = new CreateCityViewModel();
			Cites = _dataService.Cities();
		}


		void insertCity() {

			CityEntity newCity = new CityEntity();
			newCity.Name = _createCityViewModel.Name;
			_dataService.Insert(newCity);
			Cites = _dataService.Cities();

		}

		void remvoeCity(int index) {

			CityEntity city = Cites[index];
			_dataService.Delete(city);
			Cites = _dataService.Cities();
		}

		void updateCity(int index) {

			CityEntity city = Cites[index];
			_dataService.Update(city);

			Cites = _dataService.Cities();

		}
	}
}

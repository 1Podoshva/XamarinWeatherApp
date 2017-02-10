using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
namespace WeatherLibrary
{
	public class CityDataServiceViewModel : MvxViewModel
	{
		#region Property

		private List<CityObject> _cites;
		private IDataService _dataService;

		public List<CityObject> Cites
		{
			get { return _cites; }
			set { _cites = value; RaisePropertyChanged(() => Cites); }
		}

		#endregion

		public CityDataServiceViewModel(IDataService dataService) {
			_dataService = dataService;
		}
	}
}

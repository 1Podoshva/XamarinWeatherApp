using System;
using MvvmCross.Core.ViewModels;
namespace WeatherLibrary
{
	public class StartPageViewModel : MvxViewModel
	{
		private MvxCommand _showCommand = null;

		public IMvxCommand ShowCommand
		{
			get {
				_showCommand = _showCommand ?? new MvxCommand(DoShowCommand);
				return (_showCommand);
			}
		}

		public StartPageViewModel() {

		}

		private void DoShowCommand() {
			ShowViewModel<WeatherPagedViewModel>();
		}

	}
}

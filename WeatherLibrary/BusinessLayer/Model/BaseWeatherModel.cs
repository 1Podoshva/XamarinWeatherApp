using System;
using System.Net;
using MvvmCross.Core.ViewModels;
namespace WeatherLibrary
{
	public class BaseWeatherModel
	{
		#region ActionEvent

		//protected
		//

		private event Action<WebException> _errorUpdateWeaherEventHandler;

		#endregion

		#region Property

		//Protected Property
		//

		protected static WeatherManager weatherManager;

		//Public Property
		//

		public Action<WebException> ErrorUpdateWeaherEventHandler
		{
			get { return _errorUpdateWeaherEventHandler; }
			set { _errorUpdateWeaherEventHandler = value; }
		}

		#endregion

		#region Init

		public BaseWeatherModel() {

			if (weatherManager == null)
				weatherManager = WeatherManager.Instance;

		}

		#endregion
	}
}

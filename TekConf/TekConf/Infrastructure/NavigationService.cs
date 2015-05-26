using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using TekConf.Pages;

namespace TekConf.Infrastructure
{
	public class NavigationService : INavigationService
	{
		INavigation _navigation;
		MasterDetailPage _masterDetailPage;

		private INavigation Navigation
		{
			get 
			{
				if (_masterDetailPage == null) {
					_masterDetailPage = Application.Current.MainPage as MasterDetailPage;
				}

				if (_masterDetailPage != null && _navigation == null) {
					_navigation = _masterDetailPage.Navigation;
				}

				return _navigation;
			}
		}

		public async Task PushAsync (AppPage page)
		{
			switch (page) {
			case AppPage.ConferenceDetailPage:
				await Navigation.PushAsync (new LoginPage ());
				if (Device.Idiom == TargetIdiom.Phone) {
					_masterDetailPage.IsPresented = false;
				}
				break;
			case AppPage.LoginPage:
				await Navigation.PushAsync (new LoginPage ());
				break;
			default:
				throw new ArgumentOutOfRangeException ("page");
			}
		}

		public async Task PushModalAsync (AppPage page)
		{
			switch (page) {
			case AppPage.ConferenceDetailPage:
				await Navigation.PushModalAsync (new LoginPage ());
				break;
			case AppPage.LoginPage:
				await Navigation.PushModalAsync (new LoginPage ());
				break;
			//			case AppPage.DetailPage:
			//				if (Device.Idiom == TargetIdiom.Phone)
			//					mdPage.IsPresented = false;
			//				break;
			default:
				throw new ArgumentOutOfRangeException ("page");
			}
		}

		public async Task PopModalAsync (bool animated)
		{
			await Navigation.PopModalAsync (animated);
		}
	}
}
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using TekConf.Pages;

namespace TekConf.Infrastructure
{
//	public class ConferenceNavigationService : IConferenceNavigationService
//	{
//		INavigation _navigation;
//		MasterDetailPage _masterDetailPage;
//		NavigationPage _navigationPage;
//
//		private INavigation Navigation
//		{
//			get 
//			{
//				if (_masterDetailPage == null) {
//					_masterDetailPage = Application.Current.MainPage as MasterDetailPage;
//					_navigationPage = _masterDetailPage.Detail as NavigationPage;
//				}
//
//				if (_masterDetailPage != null && _navigation == null) {
//					_navigation = _navigationPage.Navigation;
//				}
//
//				return _navigation;
//			}
//		}
//
//		public async Task PushAsync (AppPage page, object parameters)
//		{
//			switch (page) {
//			case AppPage.ConferenceDetailPage:
//				await Navigation.PushAsync (new ConferenceDetailPage ((string)parameters));
//				if (Device.Idiom == TargetIdiom.Phone) {
//					_masterDetailPage.IsPresented = false;
//				}
//				break;
//			default:
//				throw new ArgumentOutOfRangeException ("page");
//			}
//		}
//
//		public async Task PushAsync (AppPage page)
//		{
//			switch (page) {
//			default:
//				throw new ArgumentOutOfRangeException ("page");
//			}
//		}
//
//		public async Task PushModalAsync (AppPage page)
//		{
//			switch (page) {
//			case AppPage.LoginPage:
//				await Navigation.PushModalAsync (new LoginPage ());
//				break;
//			default:
//				throw new ArgumentOutOfRangeException ("page");
//			}
//		}
//
//		public async Task PopModalAsync (bool animated)
//		{
//			await Navigation.PopModalAsync (animated);
//		}
//	}

	public class NavigationService : INavigationService
	{
		INavigation _navigation;
		MasterDetailPage _masterDetailPage;
		NavigationPage _navigationPage;

		private INavigation Navigation
		{
			get 
			{
				if (_masterDetailPage == null) {
					_masterDetailPage = Application.Current.MainPage as MasterDetailPage;
					_navigationPage = _masterDetailPage.Detail as NavigationPage;
				}

				if (_masterDetailPage != null && _navigation == null) {
					_navigation = _navigationPage.Navigation;
				}

				return _navigation;
			}
		}

		public async Task PushAsync (AppPage page, object parameters)
		{
			switch (page) {
			case AppPage.ConferenceDetailPage:
				await Navigation.PushAsync (new ConferenceDetailPage ((string)parameters));
				if (Device.Idiom == TargetIdiom.Phone) {
					_masterDetailPage.IsPresented = false;
				}
				break;
			default:
				throw new ArgumentOutOfRangeException ("page");
			}
		}

		public async Task PushAsync (AppPage page)
		{
			switch (page) {
			default:
				throw new ArgumentOutOfRangeException ("page");
			}
		}

		public async Task PushModalAsync (AppPage page)
		{
			switch (page) {
			case AppPage.LoginPage:
				await Navigation.PushModalAsync (new LoginPage ());
				break;
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
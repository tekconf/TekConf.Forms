using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using TekConf.Pages;

namespace TekConf.Infrastructure
{
	public class NavigationService : INavigationService
	{
		INavigation _navigation;
		TabbedPage _mainTabPage;
		NavigationPage _navigationPage;

		private INavigation Navigation
		{
			get 
			{
				if (_mainTabPage == null) {
					_mainTabPage = Application.Current.MainPage as TabbedPage;
					_navigationPage = _mainTabPage.Children[0] as NavigationPage;
				}

				if (_mainTabPage != null && _navigation == null) {
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
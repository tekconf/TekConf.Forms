using Xamarin.Forms;
using TekConf.Core.Infrastructure;

namespace TekConf.Infrastructure
{
	public class MyConferencesNavigationService : NavigationService, IMyConferencesNavigationService
	{
		public override INavigation Navigation {
			get {
				var mainTabPage = Application.Current.MainPage as TabbedPage;
				var navigationPage = mainTabPage.Children [1] as NavigationPage;

				return navigationPage.Navigation;
			}
		}
	}	
}
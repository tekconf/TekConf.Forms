using Xamarin.Forms;
using TekConf.Core.Infrastructure;

namespace TekConf.Infrastructure
{
	public class ConferencesNavigationService : NavigationService, IConferencesNavigationService
	{
		public override INavigation Navigation {
			get {
				var mainTabPage = Application.Current.MainPage as TabbedPage;
				var navigationPage = mainTabPage.Children [0] as NavigationPage;

				return navigationPage.Navigation;
			}
		}
	}
}
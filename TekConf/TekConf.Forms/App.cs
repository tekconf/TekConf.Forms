using Cirrious.CrossCore;
using TekConf.Pages;
using Xamarin.Forms;
using TekConf.Infrastructure;

namespace TekConf
{
    public class App : Application
    {
		public App()
        {
			Mvx.RegisterSingleton<INavigationService> (() => new NavigationService());

            MainPage = new MainTabPage();
		}
    }
}
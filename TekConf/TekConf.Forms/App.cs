using Cirrious.CrossCore;
using TekConf.Pages;
using Xamarin.Forms;
using TekConf.Infrastructure;
using TekConf.Core.Infrastructure;

namespace TekConf
{
    public class App : Application
    {
		public App()
        {
			Mvx.RegisterType<IConferencesNavigationService, ConferencesNavigationService> ();
			Mvx.RegisterType<IMyConferencesNavigationService, MyConferencesNavigationService> ();

            MainPage = new MainTabPage();
		}
    }
}
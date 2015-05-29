using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using TekConf.Pages;
using TekConf.ViewModels;
using Xamarin.Forms;
using TekConf.Infrastructure;
using TekConf.Core;

namespace TekConf
{
    public class App : Application
    {
		public App()
        {
			Mvx.RegisterSingleton<INavigationService> (() => new NavigationService());
			Mvx.RegisterType<IConferenceRepository, ConferenceRepository> ();

            MainPage = new MainPage();
		}

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

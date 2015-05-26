﻿using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using TekConf.Pages;
using TekConf.ViewModels;
using Xamarin.Forms;
using TekConf.Infrastructure;

namespace TekConf
{
    public class App : Application
    {
        public App()
        {
            MvxSimpleIoCContainer.Initialize();

			Mvx.RegisterType<INavigationService, NavigationService> ();

			// The root page of your application
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

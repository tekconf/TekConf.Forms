using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Cirrious.CrossCore;
using TekConf.Core.Infrastructure;
using TekConf.Pages;
using TekConf.Infrastructure;

namespace TekConf.Forms
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent ();

			Mvx.RegisterType<IConferencesNavigationService, ConferencesNavigationService> ();
			Mvx.RegisterType<IMyConferencesNavigationService, MyConferencesNavigationService> ();

			MainPage = new MainTabPage();
		}
	}
}


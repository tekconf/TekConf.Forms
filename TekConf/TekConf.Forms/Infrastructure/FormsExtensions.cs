using System;
using Xamarin.Forms;

namespace TekConf.Forms.Extensions
{
	public static class FormsExtensions
	{
		public static void HideNavBarOnAndroid(this Page page)
		{
			if (Device.OS == TargetPlatform.Android) {
				NavigationPage.SetHasNavigationBar (page, false);
			}
		}
	}
}
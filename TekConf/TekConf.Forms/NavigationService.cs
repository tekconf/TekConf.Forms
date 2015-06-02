using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using TekConf.Pages;
using TekConf.Core.Infrastructure;

namespace TekConf.Infrastructure
{
	public abstract class NavigationService : INavigationService
	{
		public abstract INavigation Navigation { get; }

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
using PropertyChanged;
using System;
using System.Windows.Input;
using TekConf.Core;
using System.Threading.Tasks;
using TekConf.Core.Infrastructure;
using Cirrious.CrossCore;

namespace TekConf.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferenceListModel : ViewModelBase
	{
		public string Name { get; set; }

		public string Slug { get; set; }

		public DateTime? Start { get; set; }

		public DateTime? End { get; set; }

		public ICommand ShowDetail { get; set; }

		private readonly IConferencesNavigationService _conferencesNavigationService;

		public ConferenceListModel ()
		{
			_conferencesNavigationService = Mvx.Resolve<IConferencesNavigationService> ();
			this.ShowDetail = new AsyncDelegateCommand<string> (async (slug) => await OnShowDetail (slug));
		}

		async Task OnShowDetail (string slug)
		{
			await _conferencesNavigationService.PushAsync (AppPage.ConferenceDetailPage, slug);
		}
	}
}
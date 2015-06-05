using PropertyChanged;
using System;
using System.Windows.Input;
using TekConf.Core;
using System.Threading.Tasks;
using TekConf.Core.Infrastructure;
using Cirrious.CrossCore;
using Humanizer;

namespace TekConf.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferenceListModel : ViewModelBase
	{
		public string Name { get; set; }

		public string Slug { get; set; }

		[AlsoNotifyFor("FormattedStart")]
		public DateTime? Start { get; set; }

		[DependsOn("Start")]
		public string FormattedStart {
			get {
				return this.Start.HasValue ? this.Start.Value.Humanize () : string.Empty;
			}
		}

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
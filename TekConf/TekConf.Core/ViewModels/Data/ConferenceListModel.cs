using PropertyChanged;
using System;
using System.Windows.Input;
using TekConf.Core;
using System.Threading.Tasks;
using TekConf.Infrastructure;
using Cirrious.CrossCore;

namespace TekConf.ViewModels.Data
{
	[ImplementPropertyChanged]
	public class ConferenceListModel : ViewModelBase
	{
		public string Name { get; set; }

		public string Slug { get; set; }

		public DateTime? Start { get; set; }

		public DateTime? End { get; set; }

		public ICommand ShowDetail { get; set; }

		public ConferenceListModel ()
		{
			this.Navigation = Mvx.Resolve<INavigationService> ();
			this.ShowDetail = new DelegateCommand<string> (async (slug) => await OnShowDetail (slug));
		}

		async Task OnShowDetail (string slug)
		{
			await this.Navigation.PushAsync (AppPage.ConferenceDetailPage, slug);
		}
	}
}
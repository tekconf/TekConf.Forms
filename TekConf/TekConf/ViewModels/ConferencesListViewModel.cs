using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.Pages;
using Xamarin.Forms;
using TekConf.ViewModels.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using TekConf.Infrastructure;

namespace TekConf.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferencesListViewModel : ViewModelBase
	{
		public ICommand ShowLogin { get; private set; }
		public ICommand ShowDetail { get; private set; }

		public ObservableCollection<ConferenceListModel> Conferences { get; set; }

		public bool IsLoading { get; set; }

		public ConferencesListViewModel ()
		{
			this.Conferences = new ObservableCollection<ConferenceListModel> ();

			this.ShowLogin = new Command (async () => await OnShowLogin ());
			this.ShowDetail = new Command<string> (async (slug) => await OnShowDetail (slug));

			GetConferences ();
		}

		async Task OnShowLogin ()
		{
			await this.Navigation.PushModalAsync (AppPage.LoginPage);
		}

		async Task OnShowDetail(string slug)
		{
			await this.Navigation.PushAsync (AppPage.LoginPage);
		}

		private async Task GetConferences ()
		{
			this.IsLoading = true;

			var conferences = new List<ConferenceListModel> () { 
				new ConferenceListModel () {
					Name = "Conference 1",
					Start = DateTime.Now.AddMonths (-1),
					End = DateTime.Now.AddDays (-15)
				}
			};

			await Task.Delay (1500);

			this.Conferences = new ObservableCollection<ConferenceListModel> (conferences);

			this.IsLoading = false;
		}
	}
}
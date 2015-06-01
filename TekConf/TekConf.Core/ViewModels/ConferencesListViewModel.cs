using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.ViewModels.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TekConf.Core;
using AutoMapper;
using Fusillade;
using TekConf.Infrastructure;

namespace TekConf.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferencesListViewModel : ViewModelBase
	{
		public ICommand Load { get; private set; }
        public ICommand ShowDetail { get; private set; }

		public ObservableCollection<ConferenceDto> Conferences { get; set; } = new ObservableCollection<ConferenceDto> ();

		public bool IsLoading { get; set; }

		readonly IConferencesService _conferencesService;

	    public ConferencesListViewModel (IConferencesService conferencesService)
		{
			_conferencesService = conferencesService;

			Load = new DelegateCommand (OnLoad);
		    ShowDetail = new AsyncDelegateCommand<ConferenceDto>(conference => OnShowDetail(conference));
		}

	    private async Task OnShowDetail(ConferenceDto conference)
	    {
	       await this.Navigation.PushAsync(AppPage.ConferenceDetailPage, conference.Slug);
	    }

		private void OnLoad ()
		{
			 GetConferences ();
		}

		private async Task GetConferences ()
		{
			this.IsLoading = true;

			var conferences = await _conferencesService
				.GetConferences (Priority.Explicit);

			this.Conferences = new ObservableCollection<ConferenceDto> (conferences);

			this.IsLoading = false;
		}
	}
}
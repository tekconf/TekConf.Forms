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
	    private ConferenceDto _selectedConference;

	    public ConferenceDto SelectedConference
	    {
	        get
	        {
	            return _selectedConference;
	        }
	        set
	        {
	            _selectedConference = value;
	        }
	    }

	    public ConferencesListViewModel (IConferencesService conferencesService)
		{
			_conferencesService = conferencesService;

			Load = new DelegateCommand (OnLoad);
		    ShowDetail = new AsyncDelegateCommand<string>(slug => OnShowDetail(slug));
		}

	    private async Task OnShowDetail(string slug)
	    {
	       await this.Navigation.PushAsync(AppPage.ConferenceDetailPage, slug);
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
			//.ConfigureAwait(false);

//			var conferences = Mapper.Map<List<ConferenceListModel>> (conferenceModels);
			this.Conferences = new ObservableCollection<ConferenceDto> (conferences);

			this.IsLoading = false;
		}
	}
}
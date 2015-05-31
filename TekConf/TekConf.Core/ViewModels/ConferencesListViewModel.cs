using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.ViewModels.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TekConf.Core;
using AutoMapper;
using Fusillade;

namespace TekConf.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferencesListViewModel : ViewModelBase
	{
		public ICommand Load { get; private set; }

		public ObservableCollection<ConferenceDto> Conferences { get; set; } = new ObservableCollection<ConferenceDto> ();

		public bool IsLoading { get; set; }

		readonly IConferencesService _conferencesService;

		public ConferencesListViewModel (IConferencesService conferencesService)
		{
			_conferencesService = conferencesService;

			Load = new DelegateCommand (OnLoad);
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
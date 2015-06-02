﻿using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fusillade;
using TekConf.Core.Infrastructure;
using TekConf.Core.Data.Dtos;
using TekConf.Core.Services;

namespace TekConf.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferencesListViewModel : ViewModelBase
	{
		public ICommand Load { get; private set; }
        public ICommand ShowDetail { get; private set; }
		public ObservableCollection<ConferenceDto> Conferences { get; set; } = new ObservableCollection<ConferenceDto> ();
		public bool IsLoading { get; set; }

		private readonly IConferencesService _conferencesService;
		private readonly IConferencesNavigationService _navigation;

		public ConferencesListViewModel (IConferencesService conferencesService, IConferencesNavigationService navigation)
		{
			_navigation = navigation;
			_conferencesService = conferencesService;

			this.Load = new AsyncDelegateCommand (async _ => await OnLoad());
			this.ShowDetail = new AsyncDelegateCommand<ConferenceDto> (async conference => await OnShowDetail(conference));
		}

	    private async Task OnShowDetail(ConferenceDto conference)
	    {
			await _navigation.PushAsync(AppPage.ConferenceDetailPage, conference.Slug);
	    }

		private async Task OnLoad ()
		{
			 await GetConferences ();
		}

		private async Task GetConferences ()
		{
			this.IsLoading = true;

			var conferences = await _conferencesService.GetConferences (Priority.Explicit);

			this.Conferences = new ObservableCollection<ConferenceDto> (conferences);

			this.IsLoading = false;
		}
	}
}
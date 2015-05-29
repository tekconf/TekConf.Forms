﻿using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.ViewModels.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TekConf.Infrastructure;
using TekConf.Core;
using AutoMapper;

namespace TekConf.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferencesListViewModel : ViewModelBase
	{
		public ICommand ShowLogin { get; private set; }
		public ICommand ShowDetail { get; private set; }

		public ObservableCollection<ConferenceListModel> Conferences { get; set; }

		public bool IsLoading { get; set; }

		readonly IConferenceRepository _conferenceRepository;

		public ConferencesListViewModel (IConferenceRepository conferenceRepository)
		{
			_conferenceRepository = conferenceRepository;

			this.Conferences = new ObservableCollection<ConferenceListModel> ();

			this.ShowLogin = new DelegateCommand (async () => await OnShowLogin ());

			Task.Run(async () => await GetConferences());
		}

		async Task OnShowLogin ()
		{
			await this.Navigation.PushModalAsync (AppPage.LoginPage);
		}

		private async Task GetConferences ()
		{
			this.IsLoading = true;

			var conferenceModels = await _conferenceRepository.GetAllAsync ();

			var conferences = Mapper.Map<List<ConferenceListModel>> (conferenceModels);
			this.Conferences = new ObservableCollection<ConferenceListModel> (conferences);

			this.IsLoading = false;
		}
	}
}
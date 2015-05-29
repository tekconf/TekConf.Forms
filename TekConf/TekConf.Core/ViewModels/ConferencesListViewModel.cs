using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.ViewModels.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using TekConf.Infrastructure;
using TekConf.Core;
using System.ComponentModel;
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

//			var conferences = new List<ConferenceListModel> () { 
//				new ConferenceListModel () {
//					Slug = "conference-1",
//					Name = "Conference 1",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Slug = "conference-2",
//					Name = "Conference 2",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 3",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 4",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 5",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 6",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 7",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 8",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 9",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 10",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 11",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 12",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 13",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 14",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 15",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//				new ConferenceListModel () {
//					Name = "Conference 16",
//					Start = DateTime.Now.AddMonths (-1),
//					End = DateTime.Now.AddDays (-15)
//				},
//			};

			//await Task.Delay (1500);

			var conferenceModels = await _conferenceRepository.GetAllAsync ();

			var conferences = Mapper.Map<List<ConferenceListModel>> (conferenceModels);
			this.Conferences = new ObservableCollection<ConferenceListModel> (conferences);

			this.IsLoading = false;
		}
	}
}
using System;
using Fusillade;
using System.Threading.Tasks;
using System.Collections.Generic;
using Akavache;
using System.Reactive.Linq;
using Connectivity.Plugin;
using Polly;
using System.Net;
using System.Linq;
using TekConf.Core.Data.Dtos;

namespace TekConf.Core.Services
{
	public class ConferencesService : IConferencesService
	{
		private readonly IApiService _apiService;

		public ConferencesService (IApiService apiService)
		{
			_apiService = apiService;
		}

		public async Task<List<ConferenceDto>> GetConferences (bool force, Priority priority)
		{
			var cache = BlobCache.LocalMachine;
			var time = new TimeSpan (hours: 0, minutes: 5, seconds: 0);

			await cache.InvalidateAllObjects<ConferenceDto> ();
			var conferences = await GetRemoteConferencesAsync (force, priority);

			var newConfs = conferences.GroupBy(x => x.Slug).Select(g => g.First());
			foreach (var conf in newConfs) {
				await cache.InsertObject<ConferenceDto> (conf.Slug, conf, DateTimeOffset.Now.Add (time));
			}

			conferences = conferences.Where (x => x.Sessions.Any ()).OrderByDescending (c => c.Start).ToList ();
			return conferences;
		}

		public async Task<List<MyConferenceDto>> GetMyConferences (bool force, Priority priority)
		{
			var cache = BlobCache.LocalMachine;
			var time = new TimeSpan (hours: 0, minutes: 5, seconds: 0);

			await cache.InvalidateAllObjects<MyConferenceDto> ();
			var myConferences = await GetRemoteMyConferencesAsync (force, priority);

			var newConfs = myConferences.GroupBy(x => x.Slug).Select(g => g.First());
			foreach (var conf in newConfs) {
				await cache.InsertObject<MyConferenceDto> (conf.Slug, conf, DateTimeOffset.Now.Add (time));
			}

			myConferences = myConferences.OrderBy (c => c.Name).ToList ();

			return myConferences;
		}

		public async Task<ConferenceDto> GetConference (Priority priority, string slug)
		{
			var cache = BlobCache.LocalMachine;

			var conference = await cache.GetObject<ConferenceDto> (slug).FirstAsync ();

			return conference;
		}

		public async Task<MyConferenceDto> GetMyConference (Priority priority, string slug)
		{
			var cache = BlobCache.LocalMachine;

			var conference = await cache.GetObject<MyConferenceDto> (slug).FirstAsync ();

			return conference;
		}

		private async Task<List<ConferenceDto>> GetRemoteConferencesAsync (bool force, Priority priority)
		{
			List<ConferenceDto> conferences = null;
			Task<List<ConferenceDto>> getConferencesTask;
			switch (priority) {
			case Priority.Background:
				getConferencesTask = _apiService.Background.GetConferences ();
				break;
			case Priority.UserInitiated:
				getConferencesTask = _apiService.UserInitiated.GetConferences ();
				break;
			case Priority.Speculative:
				getConferencesTask = _apiService.Speculative.GetConferences ();
				break;
			default:
				getConferencesTask = _apiService.UserInitiated.GetConferences ();
				break;
			}

			conferences = await Policy
					.Handle<WebException> ()
					.WaitAndRetryAsync
					(
				retryCount: 5, 
				sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds (Math.Pow (2, retryAttempt))
			).ExecuteAsync (() => getConferencesTask);
			
			if (conferences != null && conferences.Any ()) {
				if (force) {
					conferences = conferences.OrderBy (c => c.Start).ToList ();
				} else {
					conferences = conferences.OrderBy (c => c.Start).ToList ();
				
				}
			}
			return conferences;
		}

		private async Task<List<MyConferenceDto>> GetRemoteMyConferencesAsync (bool force, Priority priority)
		{
			List<MyConferenceDto> conferences = null;
			Task<List<MyConferenceDto>> getConferencesTask;
			switch (priority) {
			case Priority.Background:
				getConferencesTask = _apiService.Background.GetMyConferences ();
				break;
			case Priority.UserInitiated:
				getConferencesTask = _apiService.UserInitiated.GetMyConferences ();
				break;
			case Priority.Speculative:
				getConferencesTask = _apiService.Speculative.GetMyConferences ();
				break;
			default:
				getConferencesTask = _apiService.UserInitiated.GetMyConferences ();
				break;
			}

			conferences = await Policy
				.Handle<WebException> ()
				.WaitAndRetryAsync
				(
				retryCount: 5, 
				sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds (Math.Pow (2, retryAttempt))
			)
				.ExecuteAsync (() => getConferencesTask);

			if (conferences != null && conferences.Any ()) {
				conferences = conferences.OrderBy (c => c.Start).ToList ();
			}
			return conferences;
		}

		public async Task<ConferenceDto> GetRemoteConference (Priority priority, string slug)
		{
			ConferenceDto conference = null;

			Task<ConferenceDto> getConferenceTask;
			switch (priority) {
			case Priority.Background:
				getConferenceTask = _apiService.Background.GetConference (slug);
				break;
			case Priority.UserInitiated:
				getConferenceTask = _apiService.UserInitiated.GetConference (slug);
				break;
			case Priority.Speculative:
				getConferenceTask = _apiService.Speculative.GetConference (slug);
				break;
			default:
				getConferenceTask = _apiService.UserInitiated.GetConference (slug);
				break;
			}

			if (CrossConnectivity.Current.IsConnected) {
				conference = await Policy
					.Handle<Exception> ()
					.RetryAsync (retryCount: 5)
					.ExecuteAsync (async () => await getConferenceTask);
			}

			return conference;
		}

	}

}
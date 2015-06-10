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
			//var conferences =  await _apiService.UserInitiated.GetConferences ();

			var cache = BlobCache.LocalMachine;
		
			if (force) {
				cache.Invalidate ("conferences");
			}

			var cachedConferences = cache.GetAndFetchLatest (
										"conferences", 
										() => GetRemoteConferencesAsync (force, priority),
				                        offset => {
											TimeSpan elapsed = DateTimeOffset.Now - offset;
											return elapsed > new TimeSpan (hours: 0, minutes: 5, seconds: 0);
										}
			);

			var conferences = await cachedConferences.FirstOrDefaultAsync ();

			conferences = conferences.Where(x => x.Sessions.Any()).OrderByDescending (c => c.Start).ToList ();

			return conferences;
		}

		public async Task<List<ConferenceDto>> GetMyConferences (bool force, Priority priority)
		{
			//var myConferences =  await _apiService.UserInitiated.GetMyConferences ();

			var cache = BlobCache.LocalMachine;
			if (force) {
				cache.Invalidate ("myConferences");
			}
			var cachedConferences = cache.GetAndFetchLatest ("myConferences", () => GetRemoteMyConferencesAsync (priority),
				                           offset => {
					TimeSpan elapsed = DateTimeOffset.Now - offset;
					return elapsed > new TimeSpan (hours: 0, minutes: 5, seconds: 0);
				});
					
			var myConferences = await cachedConferences.FirstOrDefaultAsync ();

			myConferences = myConferences.OrderBy (c => c.Name).ToList ();

			return myConferences;
		}

		public async Task<ConferenceDto> GetConference (Priority priority, string slug)
		{
			var conferences = await GetConferences(false, priority);
			var conference = conferences.FirstOrDefault (c => c.Slug == slug);

			return conference;

//			var cachedConference = BlobCache.LocalMachine.GetAndFetchLatest (slug, () => GetRemoteConference (priority, slug), offset => {
//				TimeSpan elapsed = DateTimeOffset.Now - offset;
//				return elapsed > new TimeSpan (hours: 0, minutes: 5, seconds: 0);
//			});
//
//			var conference = await cachedConference.FirstOrDefaultAsync ();
//
//			return conference;
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
			)
					.ExecuteAsync (() => getConferencesTask);
			
			if (conferences != null && conferences.Any ()) {
				if (force) {
					conferences = conferences.OrderBy (c => c.Start).ToList ();
				} else {
					conferences = conferences.Take(10).OrderBy (c => c.Start).ToList ();
				
				}
			}
			return conferences;
		}

		private async Task<List<ConferenceDto>> GetRemoteMyConferencesAsync (Priority priority)
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
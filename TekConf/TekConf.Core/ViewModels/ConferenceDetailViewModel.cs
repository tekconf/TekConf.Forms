using System.Threading.Tasks;
using PropertyChanged;
using System.Windows.Input;
using TekConf.Core.Infrastructure;
using Humanizer;
using System;
using TekConf.Core.Services;
using Fusillade;

namespace TekConf.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferenceDetailViewModel : ViewModelBase
	{
		public ICommand Load { get; set; }

		public string Name { get; set; }

		public string Slug { get; set; }

		public string Description { get; set; }
		public string ImageUrl { get; set; }

		public DateTime? Start { get; set; }

		public DateTime? End { get; set; }

		private readonly IConferencesService _conferencesService;

		public ConferenceDetailViewModel (IConferencesService conferencesService)
		{
			_conferencesService = conferencesService;
			this.Load = new AsyncDelegateCommand<string> (async (slug) => await OnLoad(slug));
		}

		private async Task OnLoad(string slug)
		{
			var conference = await _conferencesService.GetConference (Priority.Explicit, slug);
			if (conference != null) {
				this.Name = conference.Name;
				this.Slug = conference.Slug;
				this.Start = conference.Start;
				this.End = conference.End;
				this.Description = conference.Description;
				this.ImageUrl = conference.ImageUrl;
			}
		}
	}
}
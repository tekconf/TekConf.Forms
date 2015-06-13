using System.Threading.Tasks;
using PropertyChanged;
using System.Windows.Input;
using TekConf.Core.Infrastructure;
using TekConf.Core.Services;
using Fusillade;
using TekConf.Core.Data.Dtos;
using System;

namespace TekConf.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferenceDetailViewModel : ViewModelBase
	{
		public ICommand Load { get; set; }
		public event EventHandler<EventArgs> Loaded = delegate{};
		private readonly IConferencesService _conferencesService;

		public ConferenceDto Conference { get; set; }

		public ConferenceDetailViewModel (IConferencesService conferencesService)
		{
			_conferencesService = conferencesService;
			this.Load = new AsyncDelegateCommand<string> (async (slug) => await OnLoad(slug));
		}

		private async Task OnLoad(string slug)
		{
			var conference = await _conferencesService.GetConference (Priority.Explicit, slug);
			if (conference != null) {
				this.Conference = conference;
				Loaded (this, new EventArgs ());
			}
		}
	}
}
using System.Threading.Tasks;
using PropertyChanged;
using System.Windows.Input;
using TekConf.Core.Infrastructure;
using Humanizer;
using System;

namespace TekConf.Core.ViewModels
{
	[ImplementPropertyChanged]
	public class ConferenceDetailViewModel : ViewModelBase
	{
		public ICommand Load { get; set; }

		public string Name { get; set; }

		public string Slug { get; set; }

		public DateTime? Start { get; set; }

		public DateTime? End { get; set; }

		public ConferenceDetailViewModel ()
		{
			this.Load = new AsyncDelegateCommand<string> (async (slug) => await OnLoad(slug));
		}

		private async Task OnLoad(string slug)
		{
			this.Slug = slug.Humanize ();
		}
	}
}
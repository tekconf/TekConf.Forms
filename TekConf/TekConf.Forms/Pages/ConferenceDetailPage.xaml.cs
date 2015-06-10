using TekConf.Pages;
using TekConf.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TekConf.Pages
{
	public class ConferenceDetailPageBase : ViewPage<ConferenceDetailViewModel> { }

	public partial class ConferenceDetailPage : ConferenceDetailPageBase
	{
		public ConferenceDetailPage (string slug)
		{
			InitializeComponent ();
			this.ViewModel.Load.Execute (slug);
			conferenceLocationMap.WidthRequest = this.Width;

		}
	}
}
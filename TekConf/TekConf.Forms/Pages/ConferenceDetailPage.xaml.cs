using TekConf.Pages;
using TekConf.ViewModels;

namespace TekConf.Pages
{
	public class ConferenceDetailPageBase : ViewPage<ConferenceDetailViewModel> { }

	public partial class ConferenceDetailPage : ConferenceDetailPageBase
	{
		public ConferenceDetailPage (string slug)
		{
			InitializeComponent ();
		}
	}
}
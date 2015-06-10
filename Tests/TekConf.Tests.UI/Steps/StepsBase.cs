using TechTalk.SpecFlow;
using TekConf.Tests.UI.Screens;
using Xamarin.UITest;

namespace TekConf.Tests.UI.Steps
{
	
	public class StepsBase
	{
		protected readonly IConferenceList conferencesListScreen;
		protected readonly IApp app;

		public StepsBase ()
		{
			app = FeatureContext.Current.Get<IApp>("App");
			conferencesListScreen = FeatureContext.Current.Get<IConferenceList> (ScreenNames.ConferencesList);
				
		}
	}
}
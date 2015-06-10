using System;

using TechTalk.SpecFlow;
using TekConf.Tests.UI.Screens;
using Xamarin.UITest;
using System.Linq;
using Should;

namespace TekConf.Tests.UI.Steps
{
	[Binding]
	public class ConferencesListSteps : StepsBase
	{
		[Given (@"I am on the conferences list screen")]
		public void GivenIAmOnTheConferencesListScreen ()
		{
			app.Screenshot ("Given I am on the conferences list screen");
		}

		[When(@"The conferences list is visible")]
		public void GivenTheConferencesListIsVisible()
		{
			//app.Repl ();
			app.WaitForElement (conferencesListScreen.conferencesList);
		}

		[Then(@"conference listings are available")]
		public void ConferenceListingsAreAvailable() 
		{
			app.Query (conferencesListScreen.conferenceListCells)
					.Count ()
					.ShouldBeGreaterThanOrEqualTo(1);
		}
	}
}
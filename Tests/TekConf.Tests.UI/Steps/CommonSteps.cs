using System;

using TechTalk.SpecFlow;
using TekConf.Tests.UI.Screens;
using Xamarin.UITest;
using System.Linq;
using Should;

namespace TekConf.Tests.UI.Steps
{
	[Binding]
	public class CommonSteps
	{
		readonly IConferenceList conferencesListScreen;
		readonly IApp app;

		public CommonSteps ()
		{
			app = FeatureContext.Current.Get<IApp>("App");
			conferencesListScreen = FeatureContext.Current.Get<IConferenceList> (ScreenNames.ConferencesList);
		}



		[Given(@"I have at least one existing task named ""(.*)""")]
		public void GivenIHaveAtLeastOneExistingTask(string taskName)
		{
//			app.WaitForElement (conferencesListScreen.addButton);
//			var count = app.Query (c => c.Marked (taskName)).Count ();
//			if (count == 0) {
//				app.Screenshot ("Give I have at least one existing task named '" + taskName + "'");
//				app.Tap (conferencesListScreen.addButton);
//
//				app.WaitForElement (addTaskScreen.nameEntry);
//				app.EnterText (addTaskScreen.nameEntry, taskName);
//				app.Tap (addTaskScreen.saveButton);
//				app.WaitForElement (c => c.Marked (taskName));
//			}
//			app.Screenshot ("Give I have at least one existing task named '" + taskName + "'");
//
//			app.Query(c => c.Marked(taskName)).Count().ShouldBeGreaterThanOrEqualTo(1);
		}

		[When (@"I add a new task called ""(.*)""")]
		public void WhenIAddANewTaskCalled (string taskName)
		{
//			app.WaitForElement (conferencesListScreen.addButton);
//			app.Tap (conferencesListScreen.addButton);
//			app.Screenshot ("When I add a new task called '" + taskName + "'");
//			app.WaitForElement (addTaskScreen.nameEntry);
//			app.EnterText (addTaskScreen.nameEntry, taskName);
//			app.Screenshot ("When I add a new task called '" + taskName + "'");
		}

		[When (@"I save the task")]
		public void WhenISaveTheTask ()
		{
//			app.Tap (addTaskScreen.saveButton);
//			app.Screenshot ("When I save the task");
		}

		[Then (@"I should see the ""(.*)"" task in the list")]
		public void ThenIShouldSeeTheTaskInTheList (string taskName)
		{
//			app.WaitForElement (c => c.Marked (taskName));
//			app.Query (c => c.Marked (taskName)).Length.ShouldBeGreaterThan (0);
//			app.Screenshot ("Then I should see the '" + taskName + "' task in the list");
		}

		[When(@"I select the task named ""(.*)""")]
		public void WhenISelectTheTaskNamed(string taskName)
		{
			app.Tap(c => c.Marked(taskName));
			app.Screenshot ("When I select the task named '" + taskName + "'");
		}
	}
}
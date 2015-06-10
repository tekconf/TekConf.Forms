using System;
using Xamarin.UITest.Queries;

namespace TekConf.Tests.UI.Screens.Android
{
	public class ConferencesList : IConferenceList
	{
		public Func<AppQuery, AppQuery> conferencesList { get; } 
				= new Func<AppQuery, AppQuery> (c => c.Class("ListView"));

		public Func<AppQuery, AppQuery> conferenceListCells { get; } 
				= new Func<AppQuery, AppQuery> (c => c.Class("ConditionalFocusLayout"));
	
	}
}

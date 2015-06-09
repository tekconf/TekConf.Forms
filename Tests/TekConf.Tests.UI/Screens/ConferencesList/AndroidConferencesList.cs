using System;
using Xamarin.UITest.Queries;

namespace TekConf.Tests.UI.Screens.Android
{
	public class ConferencesList : IConferenceList
	{
		public Func<AppQuery, AppQuery> addButton { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("Add"));
	}
}

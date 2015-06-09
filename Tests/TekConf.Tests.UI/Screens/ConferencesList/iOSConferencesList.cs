using System;
using Xamarin.UITest.Queries;

namespace TekConf.Tests.UI.Screens.iOS
{
	public class ConferencesList : IConferenceList
	{
		public Func<AppQuery, AppQuery> addButton { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("Add"));
	}
}

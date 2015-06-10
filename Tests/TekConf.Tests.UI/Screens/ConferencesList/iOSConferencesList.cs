using System;
using Xamarin.UITest.Queries;

namespace TekConf.Tests.UI.Screens.iOS
{
	public class ConferencesList : IConferenceList
	{
		public Func<AppQuery, AppQuery> conferencesList { get; } = new Func<AppQuery, AppQuery> (c => c.Class("UITableView"));
		public Func<AppQuery, AppQuery> conferenceListCells { get; } = new Func<AppQuery, AppQuery> (c => c.Class ("UITableViewCellContentView"));
	
	}
}

using System;
using Xamarin.UITest.Queries;

namespace TekConf.Tests.UI.Screens
{
	public interface IConferenceList
	{
		Func<AppQuery, AppQuery> conferencesList { get; }

		Func<AppQuery, AppQuery> conferenceListCells { get; }
	}
}
using NUnit.Framework;
using Xamarin.UITest;
using TechTalk.SpecFlow;

namespace TekConf.Tests.UI
{
	public partial class ListConferencesFeature : FeatureBase
	{
		public ListConferencesFeature (Platform platform, string iOSSimulator) 
										: base(platform, iOSSimulator)
		{
		}
	}

}
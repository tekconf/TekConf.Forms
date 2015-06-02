using System.Threading.Tasks;

namespace TekConf.Core.Infrastructure
{
	public interface IConferencesNavigationService : INavigationService {}
	public interface IMyConferencesNavigationService : INavigationService {}

	public interface INavigationService
	{
		Task PushAsync(AppPage page);
		Task PushAsync(AppPage page, object parameters);
		Task PushModalAsync(AppPage page);
		Task PopModalAsync(bool animated);
	}
}
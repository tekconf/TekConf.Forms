using System.Threading.Tasks;

namespace TekConf.Infrastructure
{
	public interface INavigationService
	{
		Task PushAsync(AppPage page);
		Task PushAsync(AppPage page, object parameters);
		Task PushModalAsync(AppPage page);
		Task PopModalAsync(bool animated);
	}
}
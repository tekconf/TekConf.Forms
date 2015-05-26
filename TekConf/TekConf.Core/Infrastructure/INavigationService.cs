using System.Threading.Tasks;

namespace TekConf.Infrastructure
{
	public interface INavigationService
	{
		Task PushAsync(AppPage page);
		Task PushModalAsync(AppPage page);
		Task PopModalAsync(bool animated);
	}
}
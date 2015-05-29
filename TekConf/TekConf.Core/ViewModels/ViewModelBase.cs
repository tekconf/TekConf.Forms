using TekConf.Infrastructure;

namespace TekConf.ViewModels
{
    public abstract class ViewModelBase : IViewModel
    {
		public INavigationService Navigation { get; set; }
    }
}
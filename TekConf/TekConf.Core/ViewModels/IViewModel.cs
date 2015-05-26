using TekConf.Infrastructure;

namespace TekConf.ViewModels
{
    public interface IViewModel
    {
        INavigationService Navigation { get; set; }
    }
}
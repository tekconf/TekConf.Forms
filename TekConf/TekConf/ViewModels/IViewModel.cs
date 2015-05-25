using Xamarin.Forms;

namespace TekConf.ViewModels
{
    public interface IViewModel
    {
        INavigation Navigation { get; set; }
    }
}
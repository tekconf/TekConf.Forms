using Xamarin.Forms;

namespace TekConf.ViewModels
{
    public class ViewModelBase : IViewModel
    {
        public INavigation Navigation { get; set; }
    }
}
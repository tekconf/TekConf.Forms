using Xamarin.Forms;
using TekConf.Infrastructure;

namespace TekConf.ViewModels
{
    public class ViewModelBase : IViewModel
    {
		public INavigationService Navigation { get; set; }
    }
}
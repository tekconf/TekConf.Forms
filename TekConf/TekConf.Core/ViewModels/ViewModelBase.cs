using TekConf.Infrastructure;
using System.ComponentModel;

namespace TekConf.ViewModels
{
    public abstract class ViewModelBase : IViewModel//, INotifyPropertyChanged
    {
		//public abstract event PropertyChangedEventHandler PropertyChanged;

		public INavigationService Navigation { get; set; }
    }
}
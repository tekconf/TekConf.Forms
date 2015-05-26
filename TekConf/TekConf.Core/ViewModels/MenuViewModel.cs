using System.Collections.Generic;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace TekConf.ViewModels
{
    [ImplementPropertyChanged]
    public class MenuViewModel : ViewModelBase
    {
        public ObservableCollection<string> MenuItems { get; set; } 

        public MenuViewModel()
        {
            var menuItems = new List<string>()
            {
                "Menu 1",
                "Menu 2"
            };

            this.MenuItems = new ObservableCollection<string>(menuItems);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekConf.ViewModels;
using Xamarin.Forms;

namespace TekConf.Pages
{
    public class MenuPageBase : ViewPage<MenuViewModel> { }

    public partial class MenuPage : MenuPageBase
    {
        public MenuPage()
        {
            InitializeComponent();
        }
    }
}

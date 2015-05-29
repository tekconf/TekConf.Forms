using TekConf.ViewModels;

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
using TekConf.Core.ViewModels;

namespace TekConf.Pages
{
    public class LoginPageBase : ViewPage<LoginViewModel> { }

    public partial class LoginPage : LoginPageBase
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
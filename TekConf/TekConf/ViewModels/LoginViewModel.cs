using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.Pages;
using Xamarin.Forms;

namespace TekConf.ViewModels
{
    [ImplementPropertyChanged]
    public class LoginViewModel : ViewModelBase
    {
        public ICommand CancelLogin { get; private set; }

        public LoginViewModel()
        {
            this.CancelLogin = new Command(async () => await OnCancelLogin());
        }

        async Task OnCancelLogin()
        {
            await this.Navigation.PopModalAsync(animated:true);
        }
    }
}
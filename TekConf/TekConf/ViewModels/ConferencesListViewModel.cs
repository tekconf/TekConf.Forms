using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.Pages;
using Xamarin.Forms;

namespace TekConf.ViewModels
{
    [ImplementPropertyChanged]
    public class ConferencesListViewModel : ViewModelBase
    {
        public ICommand ShowLogin { get; private set; }

        public ConferencesListViewModel()
        {
            this.ShowLogin = new Command(async () => await OnShowLogin());
        }

        async Task OnShowLogin()
        {
            await this.Navigation.PushModalAsync(new LoginPage());
        }
    }
}

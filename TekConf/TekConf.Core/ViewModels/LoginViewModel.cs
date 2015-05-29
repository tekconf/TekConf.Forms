using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using TekConf.Core;
using System.ComponentModel;

namespace TekConf.ViewModels
{
    [ImplementPropertyChanged]
    public class LoginViewModel : ViewModelBase
    {
		//public override event PropertyChangedEventHandler PropertyChanged;

        public ICommand CancelLogin { get; private set; }

        public LoginViewModel()
        {
			this.CancelLogin = new DelegateCommand(async () => await OnCancelLogin());
        }

        async Task OnCancelLogin()
        {
            await this.Navigation.PopModalAsync(animated:true);
        }
    }
}
using TekConf.ViewModels;

namespace TekConf.Pages
{
    public class ConferencesListPageBase : ViewPage<ConferencesListViewModel> { }

    public partial class ConferencesListPage : ConferencesListPageBase
    {
        public ConferencesListPage()
        {
            InitializeComponent();
			this.ViewModel.Load.Execute(null);
        }
    }
}
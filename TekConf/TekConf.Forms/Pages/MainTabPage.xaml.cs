using Xamarin.Forms;

namespace TekConf.Pages
{
    public partial class MainTabPage : TabbedPage
    {
        public MainTabPage()
        {
            InitializeComponent();
        }

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			foreach (var tab in this.Children) {
				var navigationPage = tab as NavigationPage;
				NavigationPage.SetHasNavigationBar (navigationPage, false);
			}
		}
    }
}
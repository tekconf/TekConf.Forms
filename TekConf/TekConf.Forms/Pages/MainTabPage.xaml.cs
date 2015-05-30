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
			var navigationPage = this.Children [0] as NavigationPage;
			NavigationPage.SetHasNavigationBar (navigationPage, true);
		}
    }
}
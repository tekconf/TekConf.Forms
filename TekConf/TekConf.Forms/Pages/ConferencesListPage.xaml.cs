using System;
using TekConf.Core.Data.Dtos;
using TekConf.Core.ViewModels;
using Xamarin.Forms;
using TekConf.Forms;

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

		public void OnConferenceSelected(object sender, EventArgs e)
		{
			if (conferencesList != null && conferencesList.SelectedItem != null) {
				var conference = this.conferencesList.SelectedItem as ConferenceDto;
				this.ViewModel.ShowDetail.Execute (conference);
			}
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (conferencesList != null) {
				this.conferencesList.SelectedItem = null;
			}
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			AppHelper.FastCellCache.FlushAllCaches ();

		}
    }
}
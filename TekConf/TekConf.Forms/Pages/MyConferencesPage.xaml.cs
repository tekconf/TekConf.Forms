using TekConf.ViewModels;
using System;
using TekConf.Core;
using TekConf.Core.Data.Dtos;

namespace TekConf.Pages
{
	public class MyConferencesPageBase : ViewPage<MyConferencesViewModel> { }

	public partial class MyConferencesPage : MyConferencesPageBase
    {

		public MyConferencesPage()
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
    }
}
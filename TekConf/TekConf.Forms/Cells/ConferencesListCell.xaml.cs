using TwinTechs.Controls;
using TekConf.Core.Data.Dtos;

namespace TekConf.Forms.Cells
{
	public partial class ConferencesListCell : FastCell
	{
		protected override void InitializeCell ()
		{
			InitializeComponent ();
		}

		protected override void SetupCell (bool isRecycled)
		{
			var conference = BindingContext as ConferenceDto;
			if (conference != null) {
				logoImage.ImageUrl = conference.ImageUrl ?? "";
				name.Text = conference.Name;
				start.Text = conference.Start.ToString ();
				address.Text = "address";
			}
		}
	}
}
using TwinTechs.Controls;
using TekConf.Core.Data.Dtos;

namespace TekConf.Forms.Cells
{
	public partial class ConferenceListSessionsListCell : FastCell
	{
		protected override void InitializeCell ()
		{
			InitializeComponent ();
		}

		protected override void SetupCell (bool isRecycled)
		{
			var session = BindingContext as SessionDto;
			if (session != null) {
//				logoImage.ImageUrl = conference.ImageUrl ?? "";
				title.Text = session.Title;
				date.Text = session.Date;
			}
		}
	}
}
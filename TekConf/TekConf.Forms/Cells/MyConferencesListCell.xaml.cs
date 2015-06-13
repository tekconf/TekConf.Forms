using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TwinTechs.Controls;
using TekConf.Core.Data.Dtos;

namespace TekConf.Forms.Cells
{
	public partial class MyConferencesListCell : FastCell
	{
		protected override void InitializeCell ()
		{
			InitializeComponent ();
		}

		protected override void SetupCell (bool isRecycled)
		{
			var conference = BindingContext as MyConferenceDto;
			if (conference != null) {
				logoImage.ImageUrl = conference.ImageUrl ?? "";
				name.Text = conference.Name;
				start.Text = conference.Start.ToString ();
				address.Text = "address";
				//				UserThumbnailView.ImageUrl = conference.ImagePath ?? "";
				//				ImageView.ImageUrl = conference.ThumbnailImagePath ?? "";
				//				NameLabel.Text = conference.Name;
				//				DescriptionLabel.Text = conference.Description;
				//				UserThumbnailView2.ImageUrl = conference.ThumbnailImagePath ?? "";
				//				UserThumbnailView3.ImageUrl = conference.ThumbnailImagePath ?? "";
				//				UserThumbnailView4.ImageUrl = conference.ThumbnailImagePath ?? "";
				//				UserThumbnailView5.ImageUrl = conference.ThumbnailImagePath ?? "";
				//				UserThumbnailView6.ImageUrl = conference.ThumbnailImagePath ?? "";
				//				UserThumbnailView7.ImageUrl = conference.ThumbnailImagePath ?? "";
			}
		}
	}
}
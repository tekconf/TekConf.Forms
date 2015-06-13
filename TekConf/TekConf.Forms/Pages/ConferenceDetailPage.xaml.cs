using TekConf.Pages;
using TekConf.Core.ViewModels;
using Xamarin.Forms.Maps;

namespace TekConf.Pages
{
	public class ConferenceDetailPageBase : ViewPage<ConferenceDetailViewModel> { }

	public partial class ConferenceDetailPage : ConferenceDetailPageBase
	{
		private string _slug;
		public ConferenceDetailPage (string slug)
		{
			InitializeComponent ();
			_slug = slug;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (this.ViewModel != null) {
				this.ViewModel.Loaded += ViewModel_Loaded;

				this.ViewModel.Load.Execute (_slug);
			}
		}

		protected override void OnDisappearing ()
		{
			if (this.ViewModel != null) {
				this.ViewModel.Loaded -= ViewModel_Loaded;
			}
			base.OnDisappearing ();
		}

		void ViewModel_Loaded (object sender, System.EventArgs e)
		{
			if (this.ViewModel != null && this.ViewModel.Conference != null && this.ViewModel.Conference.Position != null) {
				var position = this.ViewModel.Conference.Position;
				var mapPosition = new Position (latitude:position[1], longitude:position[0]);

				var mapSpan = MapSpan.FromCenterAndRadius (mapPosition, Distance.FromMiles (0.5));
				conferenceLocationMap.MoveToRegion (mapSpan);
				conferenceLocationMap.IsShowingUser = true;
				conferenceLocationMap.HasZoomEnabled = true;

				var pin = new Pin {
					Type = PinType.Place,
					Position = mapPosition,
					Label = this.ViewModel.Conference.Name,
					Address = "custom detail info"
				};
				conferenceLocationMap.Pins.Add(pin);

			}
			loadingLayout.IsVisible = false;
			detailLayout.IsVisible = true;
		}
	}
}
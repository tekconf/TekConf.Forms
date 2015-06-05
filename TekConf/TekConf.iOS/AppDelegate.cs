using Foundation;
using UIKit;
using Cirrious.CrossCore;
using TekConf.Infrastructure;
using TekConf.Core.Infrastructure;
using TekConf.Forms;

namespace TekConf.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

			Bootstrapper.Init();

			Mvx.RegisterType<IFileAccessHelper, FileAccessHelper> ();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
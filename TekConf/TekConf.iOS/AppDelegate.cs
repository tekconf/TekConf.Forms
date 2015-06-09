using Foundation;
using UIKit;
using Cirrious.CrossCore;
using TekConf.Infrastructure;
using TekConf.Core.Infrastructure;
using TekConf.Forms;
using TwinTechs.Controls;

namespace TekConf.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			#if DEBUG
			Xamarin.Calabash.Start();
			#endif

            global::Xamarin.Forms.Forms.Init();

			Bootstrapper.Init();

			Mvx.RegisterType<IFileAccessHelper, FileAccessHelper> ();

			AppHelper.FastCellCache = FastCellCache.Instance;
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
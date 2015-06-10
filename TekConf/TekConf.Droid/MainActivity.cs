using Android.App;
using Android.Content.PM;
using Android.OS;
using TekConf.Infrastructure;
using Cirrious.CrossCore;
using TekConf.Core.Infrastructure;
using TekConf.Forms;
using TwinTechs.Droid.Controls;

namespace TekConf.Droid
{
    [Activity(Label = "TekConf", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			Bootstrapper.Init();

			Mvx.RegisterType<IFileAccessHelper, FileAccessHelper> ();

			AppHelper.FastCellCache = FastCellCache.Instance;

            global::Xamarin.Forms.Forms.Init(this, bundle);
			Xamarin.FormsMaps.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}
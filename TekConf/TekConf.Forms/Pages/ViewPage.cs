using Cirrious.CrossCore;
using Xamarin.Forms;
using TekConf.Core.ViewModels;
using TekConf.Forms.Extensions;

namespace TekConf.Pages
{
    public class ViewPage<T> : ContentPage where T : class, IViewModel
    {
        readonly T _viewModel;

        public T ViewModel
        {
            get
            {
                return _viewModel;
            }
        }

        public ViewPage()
        {
            _viewModel = Mvx.IocConstruct<T>();

            if (_viewModel != null)
            {
				//var navigation = Mvx.Resolve<INavigationService> ();
				//_viewModel.Navigation = navigation;
                BindingContext = _viewModel;
            }

            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundColor = Color.White;
			this.HideNavBarOnAndroid ();
        }
    }
}
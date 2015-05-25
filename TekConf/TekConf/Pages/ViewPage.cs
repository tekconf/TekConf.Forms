using Cirrious.CrossCore;
using TekConf.ViewModels;
using Xamarin.Forms;

namespace TekConf.Pages
{

    public class ViewPage<T> : ContentPage where T : IViewModel, new()
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
                _viewModel.Navigation = this.Navigation;
                BindingContext = _viewModel;
            }

            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.BackgroundColor = Color.White;
        }
    }
}
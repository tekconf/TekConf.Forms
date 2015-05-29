using TekConf.Infrastructure;
using System.ComponentModel;

namespace TekConf.ViewModels
{
    public interface IViewModel
    {
        INavigationService Navigation { get; set; }
    }
}
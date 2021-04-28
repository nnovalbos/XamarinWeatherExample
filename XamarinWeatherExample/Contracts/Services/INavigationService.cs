using System.Threading.Tasks;
using XamarinWeatherExample.ViewModels.Base;

namespace XamarinWeatherExample.Contracts.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task CloseModalView();
    }
}

using System.Threading.Tasks;
using Acr.UserDialogs;
using XamarinWeatherExample.Contracts.Services;

namespace XamarinWeatherExample.Services
{
    public class DialogService : IDialogService
    {

        public Task ShowDialog(string title, string message, string buttonLabel)
        {
            return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
        }
    }
}
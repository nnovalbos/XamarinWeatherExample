using System.Threading.Tasks;

namespace XamarinWeatherExample.Contracts.Services
{
    public interface IDialogService
    {
        Task ShowDialog(string title, string message, string buttonLabel);
    }
}

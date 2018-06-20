using System.Threading.Tasks;

namespace Retrospective.Navigation
{
    public interface IAlertService
    {
        Task DisplayAlert(string title, string message, string cancel);
    }
}
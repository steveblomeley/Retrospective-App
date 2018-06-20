using System.Threading.Tasks;
using Xamarin.Forms;

namespace Retrospective.Navigation
{
    public class AlertService : IAlertService
    {
        private readonly Page _page;

        public AlertService(Page page)
        {
            _page = page;
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return _page.DisplayAlert(title, message, cancel);
        }
    }
}
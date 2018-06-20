using System;
using System.Threading.Tasks;
using Retrospective.Models;
using Retrospective.Views;
using Xamarin.Forms;

namespace Retrospective.Navigation
{
    public class AppNavigation : IAppNavigation
    {
        private readonly INavigation _navigation;

        public AppNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }

        public async Task AddNewItem(Action<Item> newItemAction)
        {
            await _navigation.PushModalAsync(new AddItemPage(_navigation, newItemAction));
        }

        public async Task<Page> PopModalAsync()
        {
            return await _navigation.PopModalAsync();
        }
    }
}
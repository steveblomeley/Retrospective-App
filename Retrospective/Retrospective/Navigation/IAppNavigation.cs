using System;
using System.Threading.Tasks;
using Retrospective.Models;
using Xamarin.Forms;

namespace Retrospective.Navigation
{
    public interface IAppNavigation
    {
        Task AddNewItem(Action<Item> newItemAction);
        Task<Page> PopModalAsync();
    }
}
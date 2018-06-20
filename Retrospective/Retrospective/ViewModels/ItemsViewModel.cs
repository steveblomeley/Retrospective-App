using System.Collections.ObjectModel;
using Retrospective.Models;
using Retrospective.Navigation;
using Xamarin.Forms;

namespace Retrospective.ViewModels
{
    public class ItemsViewModel
    {
        public ObservableCollection<Item> Items { get; }
        public Command AddNewItemCommand { get; }

        public ItemsViewModel(IAppNavigation appNavigation)
        {
            Items = new ObservableCollection<Item>();
            AddNewItemCommand = new Command(async () => await appNavigation.AddNewItem(Items.Add));
        }
    }
}
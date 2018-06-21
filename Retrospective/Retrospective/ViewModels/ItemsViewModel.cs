using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Retrospective.Models;
using Retrospective.Navigation;
using Xamarin.Forms;

namespace Retrospective.ViewModels
{
    public class ItemsViewModel
    {
        private string _dbFilePath;

        public ObservableCollection<Item> Items { get; }
        public Command AddNewItemCommand { get; }

        public ItemsViewModel(IAppNavigation appNavigation, string dbFilePath)
        {
            _dbFilePath = dbFilePath;
            Items = new ObservableCollection<Item>();
            AddNewItemCommand = new Command(async () => await appNavigation.AddNewItem(Items.Add));
        }
    }
}
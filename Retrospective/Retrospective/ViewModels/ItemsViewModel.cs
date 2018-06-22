using System.Collections.ObjectModel;
using Retrospective.Data;
using Retrospective.Models;
using Retrospective.Navigation;
using Xamarin.Forms;

namespace Retrospective.ViewModels
{
    public class ItemsViewModel
    {
        private readonly IRepository _repository;

        public ObservableCollection<Item> Items { get; }
        public Command AddNewItemCommand { get; }

        public ItemsViewModel(IAppNavigation appNavigation, IRepository repository)
        {
            _repository = repository;
            var items = _repository.AllItems(out var errorMsg);
            Items = new ObservableCollection<Item>(items);

            AddNewItemCommand = new Command(async () => await appNavigation.AddNewItem(AddNewItem));
        }

        private void AddNewItem(Item item)
        {
            if (_repository.AddItem(item, out var errorMsg))
            {
                Items.Add(item);
            }
        }
    }
}
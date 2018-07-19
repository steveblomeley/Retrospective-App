using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using Retrospective.Data;
using Retrospective.Models;
using Xamarin.Forms;

namespace Retrospective.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRepository _repository;

        public ObservableCollection<Item> Items { get; }
        public Command AddNewItemCommand { get; }

        public ItemsViewModel(INavigationService navigationService, IRepository repository) : base(navigationService)
        {
            _repository = repository;
            _navigationService = navigationService;

            AddNewItemCommand = new Command(async () => await AddNewItem());

            _repository.InitialiseDatabase();
            var items = _repository.AllItems(out var errorMsg);
            Items = new ObservableCollection<Item>(items);
        }

        private async Task AddNewItem()
        {
            Action<Item> saveNewItemAction = SaveNewItem;

            var addItemPageParameters = new NavigationParameters
            {
                {"SaveNewItemAction", saveNewItemAction}
            };

            await _navigationService.NavigateAsync("AddItemPage", addItemPageParameters);
        }

        private void SaveNewItem(Item item)
        {
            if (_repository.AddItem(item, out var errorMsg))
            {
                Items.Add(item);
            }
        }
    }
}
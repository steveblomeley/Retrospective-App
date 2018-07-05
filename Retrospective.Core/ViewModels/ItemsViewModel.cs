using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Retrospective.Core.Data;
using Retrospective.Core.Models;

namespace Retrospective.Core.ViewModels
{
    public class ItemsViewModel : MvxViewModel
    {
        private readonly IRepository _repository;
        private readonly IMvxNavigationService _navigationService;

        public ObservableCollection<Item> Items { get; }
        public IMvxCommand AddNewItemCommand { get; }


        public ItemsViewModel(IMvxNavigationService navigationService, IRepository repository)
        {
            _repository = repository;
            _navigationService = navigationService;

            var items = _repository.AllItems(out var errorMsg);
            Items = new ObservableCollection<Item>(items);

            AddNewItemCommand = new MvxCommand(async () => await AddNewItem());
        }

        private async Task AddNewItem()
        {
            await _navigationService.Navigate<AddItemViewModel>();
        }

        //TODO: Work out:
        //TODO: - Who's responsible for saving new item to database?
        //TODO: - Who's responsible for adding new item to the observable collection
        //TODO: Existing Action<Item> model prob won't play well with MvvmX
        //
        //private void AddNewItem(Item item)
        //{
        //    if (_repository.AddItem(item, out var errorMsg))
        //    {
        //        Items.Add(item);
        //    }
        //}
    }
}
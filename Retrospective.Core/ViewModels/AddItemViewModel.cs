using System;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Retrospective.Core.Models;

namespace Retrospective.Core.ViewModels
{
    public class AddItemViewModel : MvxViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private readonly INavigation _navigation;
        private readonly Action<Item> _newitemAction;
        private readonly IAlertService _alertService;

        public AddItemViewModel(INavigation navigation, Action<Item> newItemAction, IAlertService alertService)
        {
            _navigation = navigation;
            _newitemAction = newItemAction;
            _alertService = alertService;

            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
        }

        public async Task Save()
        {
            //TODO: tell user to enter Title before saving
            if (string.IsNullOrWhiteSpace(Title))
            {
                await _alertService.DisplayAlert("Please enter a Title",
                    "Please enter a title for this item before saving.", "OK");

                return;
            }

            var item = new Item { Title = Title.Trim(), Description = Description?.Trim() ?? string.Empty };
            _newitemAction(item);

            await _navigation.PopModalAsync();
        }

        public async Task<Page> Cancel()
        {
            return await _navigation.PopModalAsync();
        }
    }
}
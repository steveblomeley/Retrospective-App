using System;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using Retrospective.Models;
using Retrospective.Navigation;
using Xamarin.Forms;

namespace Retrospective.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        public string Description { get; set; }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly Action<Item> _newitemAction;

        public AddItemViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
        }

        public async Task Save()
        {
            //TODO: tell user to enter Title before saving
            if (string.IsNullOrWhiteSpace(Title))
            {
                await _pageDialogService.DisplayAlertAsync("Please enter a Title",
                    "Please enter a title for this item before saving.", "OK");

                return;
            }

            var item = new Item { Title = Title.Trim(), Description = Description?.Trim() ?? string.Empty };
            _newitemAction(item);

            await _navigationService.GoBackAsync();
        }

        public async Task Cancel()
        {
            await _navigationService.GoBackAsync();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            //TODO: capture the save new item action here
        }
    }
}
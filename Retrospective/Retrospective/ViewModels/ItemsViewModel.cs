using System.Collections.ObjectModel;
using Retrospective.Models;

namespace Retrospective.ViewModels
{
    public class ItemsViewModel
    {
        public ObservableCollection<Item> Items { get; }

        public ItemsViewModel()
        {

            Items = new ObservableCollection<Item>()
            {
                new Item
                {
                    Title = "Writing tests",
                    Description = "Let's keep writing tests and maintaining good test coverage"
                },
                new Item()
                {
                    Title = "Has no description"
                },
                new Item
                {
                    Title = "CI/CD",
                    Description = "Continuous Integration and Deployment are good - so let's keep doing them"
                }
            };
        }
    }
}
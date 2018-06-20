using System;
using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using Retrospective.Models;
using Retrospective.Navigation;
using Retrospective.ViewModels;

namespace Retrospective.Test.ViewModels
{
    [TestFixture]
    public class ItemsViewModelTests
    {
        private Mock<IAppNavigation> _appNavigation;
        private ItemsViewModel _sut;

        [SetUp]
        public void Setup()
        {
            _appNavigation = new Mock<IAppNavigation>();
            _sut = new ItemsViewModel(_appNavigation.Object);
        }

        [Test]
        public void ItemsProperty_DoesNotContainAnyItemsInitially()
        {
            Assert.That(_sut.Items, Is.Empty);
        }

        [Test]
        public void ItemsProperty_IsAnObservableCollection()
        {
            Assert.That(_sut.Items, Is.InstanceOf<ObservableCollection<Item>>());
        }

        [Test]
        public void AddNewItemCommand_NavigatesToTheAddNewItemPage_PassingInAReferenceToTheAddMethodOnTheItemsCollection()
        {
            _sut.AddNewItemCommand.Execute(null);

            _appNavigation.Verify(x => x.AddNewItem(It.IsAny<Action<Item>>()), Times.Once);
            _appNavigation.Verify(x => x.AddNewItem(_sut.Items.Add));
        }
    }
}

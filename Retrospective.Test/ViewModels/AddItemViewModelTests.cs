using System;
using Moq;
using NUnit.Framework;
using Retrospective.Models;
using Retrospective.Navigation;
using Retrospective.ViewModels;
using Xamarin.Forms;

namespace Retrospective.Test.ViewModels
{
    [TestFixture]
    public class AddItemViewModelTests
    {
        private Mock<INavigation> _navigation;
        private Mock<Action<Item>> _newItemAction;
        private Mock<IAlertService> _alertService;
        private AddItemViewModel _sut;

        [SetUp]
        public void Setup()
        {
            _navigation = new Mock<INavigation>();
            _newItemAction = new Mock<Action<Item>>();
            _alertService = new Mock<IAlertService>();
            _sut = new AddItemViewModel(_navigation.Object, _newItemAction.Object, _alertService.Object);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SaveCommand_DisplaysAlert_AndRemainsOnPage_IfItemTitle_IsNullOrWhitespace(string title)
        {
            _sut.Title = title;

            _sut.SaveCommand.Execute(null);

            _navigation.Verify(x => x.PopModalAsync(), Times.Never);
            _newItemAction.Verify(x => x(It.IsAny<Item>()), Times.Never);
            _alertService.Verify(x => x.DisplayAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SaveCommand_SavesItem_AndPopsThePage_IfItemTitle_IsANonNullOrWhitespaceString()
        {
            const string title = "a valid title";
            _sut.Title = title;

            _sut.SaveCommand.Execute(null);

            _navigation.Verify(x => x.PopModalAsync(), Times.Once);
            _newItemAction.Verify(x => x(It.IsAny<Item>()), Times.Once);
            _newItemAction.Verify(x => x(It.Is<Item>(i => i.Title == title)));
            _newItemAction.Verify(x => x(It.Is<Item>(i => i.Description == string.Empty)));
            _alertService.Verify(x => x.DisplayAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SaveCommand_SavesItem_WithEmptyDescription_IfNull_Empty_OrWhitespace_DescriptionIsProvided(
            string description)
        {
            _sut.Title = "a valid title";
            _sut.Description = description;

            _sut.SaveCommand.Execute(null);

            _newItemAction.Verify(x => x(It.IsAny<Item>()), Times.Once);
            _newItemAction.Verify(x => x(It.Is<Item>(i => i.Description == string.Empty)));
        }

        [Test]
        public void SaveCommand_SavesItem_AndPopsThePage_IfItemTitleAndDescription_AreNonNullOrWhitespaceStrings()
        {
            const string title = "a valid title";
            const string description = "a fine description";

            _sut.Title = title;
            _sut.Description = description;

            _sut.SaveCommand.Execute(null);

            _navigation.Verify(x => x.PopModalAsync(), Times.Once);
            _newItemAction.Verify(x => x(It.IsAny<Item>()), Times.Once);
            _newItemAction.Verify(x => x(It.Is<Item>(i => i.Title == title)));
            _newItemAction.Verify(x => x(It.Is<Item>(i => i.Description == description)));
            _alertService.Verify(x => x.DisplayAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SaveCommand_RemovesLeadingAndTrailingBlanks_FromTitleAndDescription_BeforeSavingItem()
        {
            const string title = "  a valid title  ";
            const string description = "  a fine description  ";

            _sut.Title = title;
            _sut.Description = description;

            _sut.SaveCommand.Execute(null);

            _navigation.Verify(x => x.PopModalAsync(), Times.Once);
            _newItemAction.Verify(x => x(It.IsAny<Item>()), Times.Once);
            _newItemAction.Verify(x => x(It.Is<Item>(i => i.Title == title.Trim())));
            _newItemAction.Verify(x => x(It.Is<Item>(i => i.Description == description.Trim())));
            _alertService.Verify(x => x.DisplayAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void CancelCommand_DoesNotSaveItem_DoesNotDisplayAlert_AndPopsThePage()
        {
            _sut.Title = "title";
            _sut.Description = "description";

            _sut.CancelCommand.Execute(null);

            _navigation.Verify(x => x.PopModalAsync(), Times.Once);
            _newItemAction.Verify(x => x(It.IsAny<Item>()), Times.Never);
            _alertService.Verify(x => x.DisplayAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
using System;
using Retrospective.Models;
using Retrospective.Navigation;
using Retrospective.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Retrospective.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddItemPage : ContentPage
	{
		public AddItemPage (INavigation navigation, Action<Item> newItemAction)
		{
			InitializeComponent ();
		    BindingContext = new AddItemViewModel(navigation, newItemAction, new AlertService(this));
		}
	}
}
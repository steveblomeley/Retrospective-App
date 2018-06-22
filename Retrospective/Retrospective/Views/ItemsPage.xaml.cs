using Retrospective.Data;
using Retrospective.Navigation;
using Retrospective.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Retrospective.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
		public ItemsPage (IRepository repository)
		{
			InitializeComponent ();

		    //TODO: Wire in an IoC Container to do this stuff
		    var appNavigation = new AppNavigation(Navigation);

		    BindingContext = new ItemsViewModel(appNavigation, repository);
		}
	}
}
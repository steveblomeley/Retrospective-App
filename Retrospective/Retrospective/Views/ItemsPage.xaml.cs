using Retrospective.Navigation;
using Retrospective.ViewModels;
using Retrospective.XPlatform;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Retrospective.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
		public ItemsPage ()
		{
			InitializeComponent ();
		    var dbFilePath = DependencyService.Get<ILocalFilesystem>().GetLocalFilePath("Retrospective-App.db3");
		    BindingContext = new ItemsViewModel(new AppNavigation(Navigation), dbFilePath);
		}
	}
}
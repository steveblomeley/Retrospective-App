using Prism.DryIoc;
using Retrospective.Data;
using Retrospective.Views;
using Retrospective.XPlatform;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Retrospective
{
	public partial class App : PrismApplication
	{
		public App ()
		{
			InitializeComponent();

            //App composition
            //TODO: Wire in an IoC Container to do this stuff
            var dbFilePath = DependencyService.Get<ILocalFilesystem>().GetLocalFilePath("Retrospective-App.db3");
		    var connectionFactory = new SqLiteConnectionFactory(dbFilePath);
            var repository = new Repository(connectionFactory);

            repository.InitialiseDatabase();

            MainPage = new ItemsPage(repository);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

using Unity;
using Prism;
using Prism.Unity;
using Prism.Ioc;
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
	    /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
	    public App() : this(null) { }

	    public App(IPlatformInitializer initializer) : base(initializer) { }

	    protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            await NavigationService.NavigateAsync("ItemsPage");
		}

	    protected override void RegisterTypes(IContainerRegistry containerRegistry)
	    {
	        //containerRegistry.RegisterForNavigation<NavigationPage>();
	        containerRegistry.RegisterForNavigation<ItemsPage>();
	        containerRegistry.RegisterForNavigation<AddItemPage>();

            //TODO: Wire in an IoC Container to do this stuff
            //TODO: using: containerRegistry.Register<IFrom, To>();
            //TODO: BUT: We need something like container.Register<IFoo,Foor>().UsingParameter("dbFileName", "Retrospective-App.db3")
            //TODO: ...so that we can pass in the database filename from the application config
	        var ctr = containerRegistry.GetContainer();
	        //ctr.RegisterType<IFrom, To>();

            var dbFilePath = DependencyService.Get<ILocalFilesystem>().GetLocalFilePath("Retrospective-App.db3");
	        var connectionFactory = new SqLiteConnectionFactory(dbFilePath);
	        var repository = new Repository(connectionFactory);

	        repository.InitialiseDatabase();

	        MainPage = new ItemsPage(repository);
	    }
    }
}
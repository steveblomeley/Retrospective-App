using Unity;
using Prism;
using Prism.Unity;
using Prism.Ioc;
using Retrospective.Data;
using Retrospective.Views;
using Retrospective.XPlatform;
using Unity.Injection;
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

	        var ctr = containerRegistry.GetContainer();
	        ctr.RegisterType<IConnectionFactory,SqLiteConnectionFactory>(
	            new InjectionConstructor(
	                new ResolvedParameter<ILocalFilesystem>(), "Retrospective-App.db3"));
	        ctr.RegisterType<IRepository, Repository>();
	    }
    }
}
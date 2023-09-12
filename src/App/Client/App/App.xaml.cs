[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Functionland.FxBlox.Client.App
{
    public partial class App
    {
        private IExceptionHandler ExceptionHandler { get; }
        public IServiceProvider ServiceProvider { get; set; }

        public App(MainPage mainPage, IExceptionHandler exceptionHandler, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new NavigationPage(mainPage);
            ExceptionHandler = exceptionHandler;
            ServiceProvider = serviceProvider;
        }

        protected override void OnStart()
        {
            base.OnStart();
            _ = Task.Run(async () => { await ServiceProvider.RunAppEvents(); });
        }
    }
}
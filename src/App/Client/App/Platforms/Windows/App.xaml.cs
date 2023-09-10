using Microsoft.UI.Xaml;

namespace Functionland.FxBlox.Client.App.Platforms.Windows
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiAppBuilder().Build();
    }
}
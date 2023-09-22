using Android.Content;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android = Android;

namespace Functionland.FxBlox.Client.App.Platforms.Android.Implementations
{
    public partial class AndroidWalletService : WalletService
    {
        public override void OpenConnectWallet(string url)
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.AddCategory("android.intent.category.DEFAULT");
            intent.SetData(android.Net.Uri.Parse(url));
            Platform.CurrentActivity?.StartActivity(intent);
        }
    }
}

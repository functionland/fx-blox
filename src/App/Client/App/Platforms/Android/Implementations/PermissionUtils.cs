using Android.Content;
using Functionland.FxBlox.Client.App.Platforms.Android.PermissionsUtility;
using Functionland.FxFiles.Client.App.Platforms.Android.Contracts;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android = Android;

namespace Functionland.FxBlox.Client.App.Platforms.Android.Implementations
{
    public class PermissionUtils : IPermissionUtils
    {
        public async Task<PermissionStatus> RequestPermission()
        {
            return await Permissions.RequestAsync<BloxAndroidPermission>();
        }

        public async Task<PermissionStatus> CheckPermission()
        {
            return await Permissions.CheckStatusAsync<BloxAndroidPermission>();
        }
    }
}

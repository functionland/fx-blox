using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Permission = Android.Manifest.Permission;

namespace Functionland.FxBlox.Client.App.Platforms.Android.PermissionsUtility;

public class BloxAndroidPermission : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new List<(string androidPermission, bool isRuntime)> {
                (Permission.AccessFineLocation, true)

        }.ToArray();
}


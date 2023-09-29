using Android.App;
using Android.Content;

namespace Functionland.FxFiles.Client.App.Platforms.Android.Contracts
{
    public interface IPermissionUtils
    {
        Task<PermissionStatus> CheckPermission();
        Task<PermissionStatus> RequestPermission();
    }
}
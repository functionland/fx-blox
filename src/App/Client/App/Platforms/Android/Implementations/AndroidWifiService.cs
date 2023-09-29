using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionland.FxBlox.Client.Core.Models;
using Android.Net.Wifi;
using WifiInfo = Functionland.FxBlox.Client.Core.Models.WifiInfo;
using Android.Content;
using Android.Views.InputMethods;
using Functionland.FxFiles.Client.App.Platforms.Android.Contracts;
using Functionland.FxBlox.Client.App.Platforms.Android.Implementations;

namespace Functionland.FxFiles.Client.App.Platforms.Android.Implementations;


public partial class AndroidWifiService : IWifiService
{
   [AutoInject] private IPermissionUtils PermissionUtils { get; set; }
   
    public async Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken = default)
    {
        var permissionStatus = await PermissionUtils.CheckPermission();

        if(permissionStatus != PermissionStatus.Granted)
        {
            await PermissionUtils.RequestPermission();
        }
       
        IEnumerable<ScanResult> availableNetworks = null;
        var wifiMgr = (WifiManager)MauiApplication.Current.GetSystemService(Context.WifiService);
        var wifiReceiver = new WifiReceiver(wifiMgr);

        await Task.Run(() =>
        {
            MauiApplication.Current.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            availableNetworks = wifiReceiver.Scan();
        });

        return availableNetworks.Select(i => new WifiInfo() { Ssid = i.Ssid, Rssi = i.Level, Essid = i.Bssid }).ToList();
    }

    public async Task ConnectAsync(WifiInfo hotspot)
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}
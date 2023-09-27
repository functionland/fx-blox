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

namespace Functionland.FxFiles.Client.App.Platforms.Android.Implementations;


public class AndroidDemoWifiService : FakeWifiService
{
    public override async Task<List<WifiInfo>> GetWifiListAsync(CancellationToken cancellationToken = default)
    {
        var wifiMgr = (WifiManager)MauiApplication.Current.GetSystemService(Context.WifiService);
        var wifiReceiver = new WifiReceiver(wifiMgr);

        var availableNetworks = await Task.Run(() =>
        {
            MauiApplication.Current.RegisterReceiver(wifiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            return wifiReceiver.Scan();
        });

        var result = availableNetworks
               .Select(i => new WifiInfo()
               {
                   Ssid = i.Ssid,
                   Rssi = i.Level,
                   Essid = i.Bssid
               }).ToList();

        result.Add(new WifiInfo() { Ssid = "Blox (Fake)", Essid = "Some ESSID", Rssi = 12 });
        
        return result;
    }
}

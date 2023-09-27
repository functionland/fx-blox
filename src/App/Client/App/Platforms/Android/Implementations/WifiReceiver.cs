using Android.Content;
using Android.Net.Wifi;

namespace Functionland.FxFiles.Client.App.Platforms.Android.Implementations;

[BroadcastReceiver(Enabled = true, Exported = false)]
class WifiReceiver : BroadcastReceiver
{
    private WifiManager wifi;
    private List<ScanResult> wifiNetworks;
    private AutoResetEvent receiverARE;
    private const int TIMEOUT_MILLIS = 20000;

    public WifiReceiver()
    {

    }
    public WifiReceiver(WifiManager wifi)
    {
        this.wifi = wifi;
        wifiNetworks = new List<ScanResult>();
        receiverARE = new AutoResetEvent(false);
    }

    public IEnumerable<ScanResult> Scan()
    {
        wifi.StartScan();
        receiverARE.WaitOne();
        return wifiNetworks;
    }

    public override void OnReceive(Context context, Intent intent)
    {
        IList<ScanResult> scanwifinetworks = wifi.ScanResults.Where(e => !string.IsNullOrWhiteSpace(e.Ssid)).ToList();
        foreach (ScanResult wifinetwork in scanwifinetworks)
        {
            wifiNetworks.Add(wifinetwork);
        }

        receiverARE.Set();
    }

    private void Timeout(object sender)
    {
        receiverARE.Set();
    }
}
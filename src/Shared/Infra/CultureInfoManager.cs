using System.Globalization;
using System.Reflection;

namespace Functionland.FxBlox.Shared.Infra;
public class CultureInfoManager
{
    public static (string name, string code) DefaultCulture { get; } = ("English", "en-US");

    public static (string name, string code)[] SupportedCultures { get; } = new (string name, string code)[]
    {
        ("English US", "en-US"),
        ("English UK", "en-GB"),
        ("Française", "fr-FR")
    };

    public static CultureInfo CreateCultureInfo(string cultureInfoId)
    {
        var cultureInfo = OperatingSystem.IsBrowser() ? CultureInfo.CreateSpecificCulture(cultureInfoId) : new CultureInfo(cultureInfoId);

        return cultureInfo;
    }

    public static void SetCurrentCulture(string? cultureInfoCookie)
    {
        var currentCulture = GetCurrentCulture(cultureInfoCookie);

        var cultureInfo = CreateCultureInfo(currentCulture);

        CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = cultureInfo;
    }

    public static string GetCurrentCulture(string? preferredCultureCookie)
    {
        string culture = CultureInfo.CurrentUICulture.Name;
        if (preferredCultureCookie is not null)
        {
            culture = preferredCultureCookie[(preferredCultureCookie.IndexOf("|uic=") + 5)..];
        }
        if (SupportedCultures.Any(sc => sc.code == culture) is false)
        {
            culture = DefaultCulture.code;
        }
        return culture;
    }

    
    private static readonly FieldInfo _cultureDataField = typeof(TextInfo).GetField("_cultureData", BindingFlags.NonPublic | BindingFlags.Instance)!;

    private static readonly FieldInfo _iReadingLayoutField = Type.GetType("System.Globalization.CultureData, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e")!.GetField("_iReadingLayout", BindingFlags.NonPublic | BindingFlags.Instance)!;
}

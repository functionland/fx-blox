namespace Functionland.FxBlox.Shared.Dtos.Authentication
{
    public class ClientPanelTokenDto
    {
        public string? DeviceInfo { get; set; }

        public string? DeviceType { get; set; }

        public string? Os { get; set; }

        public string? OsVersion { get; set; }

        public string? Browser { get; set; }

        public string? BrowserVersion { get; set; }

        public string? Model { get; set; }

        public string? Brand { get; set; }

        public string? UserAgent { get; set; }

        public required string Ip { get; set; }

    }
}

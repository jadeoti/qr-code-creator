namespace qr_code_creator.Models;

public enum QrType
{
    Url,
    Wifi
}

public enum WifiAuthType
{
    WPA,
    WEP,
    None
}

public class QrCodeViewModel
{
    public QrType QrType { get; set; } = QrType.Url;

    public string? Url { get; set; }

    public string? Ssid { get; set; }

    public string? Password { get; set; }

    public WifiAuthType AuthType { get; set; } = WifiAuthType.WPA;

    public string? QrCodeImage { get; set; }
}

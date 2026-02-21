using QRCoder;

namespace QrCodeCreator.Services;

public class QrCodeService
{
    /// <summary>
    /// Generates an SVG QR code for a given URL.
    /// </summary>
    public string GenerateUrlQrCode(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("URL cannot be empty.", nameof(url));

        var payload = new PayloadGenerator.Url(url);
        return RenderSvg(payload.ToString());
    }

    /// <summary>
    /// Generates an SVG QR code for WiFi credentials.
    /// </summary>
    public string GenerateWifiQrCode(string ssid, string? password, bool isHidden = false)
    {
        if (string.IsNullOrWhiteSpace(ssid))
            throw new ArgumentException("SSID cannot be empty.", nameof(ssid));

        var authMode = string.IsNullOrEmpty(password)
            ? PayloadGenerator.WiFi.Authentication.nopass
            : PayloadGenerator.WiFi.Authentication.WPA;

        var payload = new PayloadGenerator.WiFi(ssid, password ?? "", authMode, isHidden);
        return RenderSvg(payload.ToString());
    }

    private static string RenderSvg(string content)
    {
        using var qrCodeData = QRCodeGenerator.GenerateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        using var svgRenderer = new SvgQRCode(qrCodeData);
        return svgRenderer.GetGraphic(20);
    }
}

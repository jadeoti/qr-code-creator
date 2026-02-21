using QRCoder;

namespace qr_code_creator.Services;

public class QrCodeService
{
    public byte[] GenerateQrCodePng(string content, int pixelsPerModule = 10)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(pixelsPerModule);
    }

    public byte[] GenerateUrlQrCode(string url)
    {
        return GenerateQrCodePng(url);
    }

    public byte[] GenerateWifiQrCode(string ssid, string password, string authType)
    {
        var wifiString = $"WIFI:T:{authType};S:{ssid};P:{password};;";
        return GenerateQrCodePng(wifiString);
    }
}

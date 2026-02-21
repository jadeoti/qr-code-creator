using Microsoft.AspNetCore.Mvc;
using qr_code_creator.Models;
using qr_code_creator.Services;

namespace qr_code_creator.Controllers;

public class QrCodeController : Controller
{
    private readonly QrCodeService _qrCodeService;

    public QrCodeController(QrCodeService qrCodeService)
    {
        _qrCodeService = qrCodeService;
    }

    public IActionResult Index()
    {
        return View(new QrCodeViewModel());
    }

    [HttpPost]
    public IActionResult Generate(QrCodeViewModel model)
    {
        byte[] qrCodeBytes;

        if (model.QrType == QrType.Url)
        {
            if (string.IsNullOrWhiteSpace(model.Url))
            {
                ModelState.AddModelError(nameof(model.Url), "Please enter a URL.");
                return View("Index", model);
            }
            qrCodeBytes = _qrCodeService.GenerateUrlQrCode(model.Url);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(model.Ssid))
            {
                ModelState.AddModelError(nameof(model.Ssid), "Please enter a WiFi SSID.");
                return View("Index", model);
            }
            qrCodeBytes = _qrCodeService.GenerateWifiQrCode(
                model.Ssid,
                model.Password ?? string.Empty,
                model.AuthType.ToString());
        }

        model.QrCodeImage = Convert.ToBase64String(qrCodeBytes);
        return View("Index", model);
    }
}

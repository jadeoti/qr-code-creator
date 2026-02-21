using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QrCodeCreator.Services;

namespace QrCodeCreator.Pages;

public class WifiModel : PageModel
{
    private readonly QrCodeService _qrCodeService;
    private readonly ILogger<WifiModel> _logger;

    public WifiModel(QrCodeService qrCodeService, ILogger<WifiModel> logger)
    {
        _qrCodeService = qrCodeService;
        _logger = logger;
    }

    [BindProperty]
    [Required(ErrorMessage = "Please enter a network name (SSID).")]
    public string? Ssid { get; set; }

    [BindProperty]
    public string? Password { get; set; }

    [BindProperty]
    public bool IsHidden { get; set; }

    public string? QrCodeSvg { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            QrCodeSvg = _qrCodeService.GenerateWifiQrCode(Ssid!, Password, IsHidden);
            _logger.LogInformation("Generated WiFi QR code for SSID: {Ssid}", Ssid);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate WiFi QR code for SSID: {Ssid}", Ssid);
            ModelState.AddModelError(string.Empty, "Failed to generate QR code. Please try again.");
        }

        return Page();
    }
}

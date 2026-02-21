using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QrCodeCreator.Services;

namespace QrCodeCreator.Pages;

public class IndexModel : PageModel
{
    private readonly QrCodeService _qrCodeService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(QrCodeService qrCodeService, ILogger<IndexModel> logger)
    {
        _qrCodeService = qrCodeService;
        _logger = logger;
    }

    [BindProperty]
    [Required(ErrorMessage = "Please enter a URL.")]
    [Url(ErrorMessage = "Please enter a valid URL.")]
    public new string? Url { get; set; }

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
            QrCodeSvg = _qrCodeService.GenerateUrlQrCode(Url!);
            _logger.LogInformation("Generated URL QR code for: {Url}", Url);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate QR code for URL: {Url}", Url);
            ModelState.AddModelError(string.Empty, "Failed to generate QR code. Please try again.");
        }

        return Page();
    }
}

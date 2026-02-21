# QR Code Creator

A .NET 10 web application that generates QR codes for URLs and WiFi credentials.

## Features

- **URL QR Codes** — Enter any URL and generate a scannable QR code
- **WiFi QR Codes** — Generate QR codes for WiFi network credentials (SSID, password, hidden network support)
- **SVG Output** — Crisp, scalable QR codes rendered as inline SVG
- **Responsive Design** — Works on desktop and mobile browsers

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Getting Started

```bash
# Clone the repository
git clone https://github.com/jadeoti/qr-code-creator.git
cd qr-code-creator

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

Open **https://localhost:5001** in your browser.

## Project Structure

```
├── Pages/
│   ├── Index.cshtml          # URL QR code generator page
│   ├── Wifi.cshtml           # WiFi QR code generator page
│   ├── Error.cshtml          # Error page
│   └── Shared/
│       └── _Layout.cshtml    # Shared layout with navigation
├── Services/
│   └── QrCodeService.cs      # QR code generation logic
├── wwwroot/
│   └── css/
│       └── site.css          # Application styles
├── Program.cs                # Application entry point
└── QrCodeCreator.csproj      # Project file
```

## Tech Stack

- **ASP.NET Core** Razor Pages (.NET 10)
- **[QRCoder](https://github.com/Shane32/QRCoder)** — QR code generation library

## License

MIT

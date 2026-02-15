# Sob Medida Cortinas - ASP.NET Core 8

Migrated from ASP.NET MVC 5 (.NET Framework 4.5) to ASP.NET Core 8.

## Prerequisites

- .NET 8 SDK
- Node.js 18+ and npm

## Setup

### 1. Restore .NET packages

```bash
dotnet restore
```

### 2. Install npm dependencies

```bash
npm install
```

### 3. Build LESS files

```bash
npm run build
```

### 4. Configure secrets

Create `appsettings.Development.json` (already exists with development keys) or set environment variables:

```bash
export ReCaptcha__SecretKey="your-recaptcha-secret-key"
export SendGrid__ApiKey="your-sendgrid-api-key"
```

For production, use environment variables instead of storing secrets in files:

- `ReCaptcha__SecretKey` - Your reCAPTCHA v2 secret key
- `SendGrid__ApiKey` - Your SendGrid API key

## Running the application

### Development mode

```bash
dotnet run
```

The application will be available at:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001

### Watch LESS files for changes

In a separate terminal:

```bash
npm run watch:less
```

## Project Structure

- `Controllers/` - MVC controllers
- `Models/` - Data models
- `Views/` - Razor views
- `Services/` - Business logic services
  - `ProductService` - Manages product data from JSON files
  - `ReCaptchaService` - Handles reCAPTCHA validation
  - `SendGridEmailService` - Sends emails via SendGrid
- `Data/` - JSON data files (cortinas, persianas, ideias)
- `wwwroot/` - Static files (CSS, JS, images)

## Key Changes from MVC 5

1. **Data Management**: Product data extracted to JSON files instead of hardcoded in models
2. **Dependency Injection**: Services registered and injected via DI container
3. **Configuration**: Secrets moved to configuration files (excluded from git)
4. **Build System**: Replaced Grunt with npm scripts for LESS compilation
5. **Cross-Platform**: Now runs on Windows, Linux, and macOS

## Security Improvements

- ✅ No hardcoded secrets in source code
- ✅ Configuration-based secret management
- ✅ Environment variable support for production
- ✅ Comprehensive logging via ILogger
- ✅ Input validation with Data Annotations

## Contact Form

The contact form uses:
- Google reCAPTCHA v2 for spam protection (skipped in DEBUG mode)
- SendGrid for email delivery
- Client-side validation with jqBootstrapValidation

## Building for Production

```bash
dotnet publish -c Release -o ./publish
```

Set environment variables before running:

```bash
export ASPNETCORE_ENVIRONMENT=Production
export ReCaptcha__SecretKey="your-production-recaptcha-key"
export SendGrid__ApiKey="your-production-sendgrid-key"

cd publish
dotnet SobMedidaCortinas.Web.Core.dll
```

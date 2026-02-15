using Microsoft.AspNetCore.Mvc;
using SobMedidaCortinas.Web.Core.Models;
using SobMedidaCortinas.Web.Core.Services;

namespace SobMedidaCortinas.Web.Core.Controllers;

public class ContatoController : Controller
{
    private readonly IEmailService _emailService;
    private readonly IReCaptchaService _reCaptchaService;
    private readonly ILogger<ContatoController> _logger;
    private readonly IWebHostEnvironment _environment;

    public ContatoController(
        IEmailService emailService,
        IReCaptchaService reCaptchaService,
        ILogger<ContatoController> logger,
        IWebHostEnvironment environment)
    {
        _emailService = emailService;
        _reCaptchaService = reCaptchaService;
        _logger = logger;
        _environment = environment;
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactModel request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { error = "invalidData" });
            }

#if !DEBUG
            // Validate reCAPTCHA in production
            var gCaptchaResponse = Request.Form["g-recaptcha-response"].ToString();
            var remoteIp = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (!await _reCaptchaService.ValidateAsync(gCaptchaResponse, remoteIp))
            {
                _logger.LogWarning("ReCAPTCHA validation failed for contact form submission from {RemoteIp}", remoteIp);
                Response.StatusCode = 400;
                return Content("invalidCaptcha");
            }
#else
            _logger.LogInformation("Skipping ReCAPTCHA validation in DEBUG mode");
#endif

            await _emailService.SendContactEmailAsync(request);
            _logger.LogInformation("Contact form submitted successfully by {Email}", request.Email);

            return Json("ok");
        }
        catch (SendEmailException ex)
        {
            _logger.LogError(ex, "Failed to send contact email");
            return Json(new { error = "failedToSendEmail" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error processing contact form");

            // In case of unexpected error, still try to send email with error details
            try
            {
                request.Mensagem += "\r\n=======CAPTCHA FALHOU=======\r\n" + ex.ToString();
                await _emailService.SendContactEmailAsync(request);
            }
            catch
            {
                // Ignore errors when trying to send error notification
            }

            return Json("ok");
        }
    }
}

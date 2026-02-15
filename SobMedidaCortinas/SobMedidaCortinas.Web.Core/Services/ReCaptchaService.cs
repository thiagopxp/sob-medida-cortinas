using Newtonsoft.Json.Linq;

namespace SobMedidaCortinas.Web.Core.Services;

public class ReCaptchaService : IReCaptchaService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ReCaptchaService> _logger;

    public ReCaptchaService(HttpClient httpClient, IConfiguration configuration, ILogger<ReCaptchaService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<bool> ValidateAsync(string gCaptchaResponse, string? remoteIp = null)
    {
        if (string.IsNullOrWhiteSpace(gCaptchaResponse))
        {
            _logger.LogWarning("ReCAPTCHA response is empty");
            return false;
        }

        try
        {
            var secretKey = _configuration["ReCaptcha:SecretKey"];
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                _logger.LogError("ReCAPTCHA SecretKey is not configured");
                return false;
            }

            var values = new Dictionary<string, string>
            {
                {"secret", secretKey},
                {"response", gCaptchaResponse}
            };

            if (!string.IsNullOrWhiteSpace(remoteIp))
            {
                values.Add("remoteip", remoteIp);
            }

            var content = new FormUrlEncodedContent(values);
            var response = await _httpClient.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var captchaResponse = JObject.Parse(responseString);

            var success = captchaResponse["success"]?.Value<bool>() ?? false;

            if (!success)
            {
                var errorCodes = captchaResponse["error-codes"]?.ToString();
                _logger.LogWarning("ReCAPTCHA validation failed. Error codes: {ErrorCodes}", errorCodes);
            }

            return success;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating ReCAPTCHA");
            return false;
        }
    }
}

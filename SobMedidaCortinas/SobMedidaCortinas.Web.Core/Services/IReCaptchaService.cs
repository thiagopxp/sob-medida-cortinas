namespace SobMedidaCortinas.Web.Core.Services;

public interface IReCaptchaService
{
    Task<bool> ValidateAsync(string gCaptchaResponse, string? remoteIp = null);
}

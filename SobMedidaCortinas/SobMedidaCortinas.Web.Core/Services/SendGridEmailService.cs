using SendGrid;
using SendGrid.Helpers.Mail;
using SobMedidaCortinas.Web.Core.Models;

namespace SobMedidaCortinas.Web.Core.Services;

public class SendGridEmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<SendGridEmailService> _logger;

    public SendGridEmailService(IConfiguration configuration, ILogger<SendGridEmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SendContactEmailAsync(ContactModel contactData)
    {
        try
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey) || apiKey == "YOUR_SENDGRID_API_KEY_HERE")
            {
                _logger.LogWarning("SendGrid API key is not configured. Email will not be sent.");
                throw new SendEmailException("SendGrid API key is not configured");
            }

            var fromAddress = _configuration["Email:FromAddress"] ?? "contato@sobmedidacortinas.com.br";
            var toAddress = _configuration["Email:ToAddress"] ?? "contato@sobmedidacortinas.com.br";

            string plainTextContent = string.Format(
                "PEDIDO DE ORÇAMENTO\r\n\r\nNome: {0}\r\n Telefone: {1}\r\n E-mail: {2}\r\n Bairro: {3}\r\n Mensagem: {4}\r\n",
                contactData.Nome, contactData.Telefone, contactData.Email, contactData.Bairro, contactData.Mensagem);

            string htmlContent = $"<html><body>{plainTextContent.Replace("\r\n", "<br/>")}</body></html>";

            var client = new SendGridClient(apiKey);

            var message = MailHelper.CreateSingleEmail(
                new EmailAddress(fromAddress),
                new EmailAddress(toAddress),
                "PO (" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ")",
                plainTextContent,
                htmlContent);

            message.SetReplyTo(new EmailAddress(contactData.Email, contactData.Nome));

            // Add BCC addresses from configuration
            var bccAddresses = _configuration.GetSection("Email:BccAddresses").Get<string[]>();
            if (bccAddresses != null && bccAddresses.Length > 0)
            {
                var bccList = bccAddresses.Select(addr => new EmailAddress(addr)).ToList();
                message.AddBccs(bccList);
            }
            else
            {
                // Default BCC address
                message.AddBccs(new List<EmailAddress> { new EmailAddress("thiagopxp@gmail.com") });
            }

            var response = await client.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                string body = await response.Body.ReadAsStringAsync();
                _logger.LogError("Failed to send email. Status: {StatusCode}, Body: {Body}", response.StatusCode, body);
                throw new SendEmailException($"Failed to send message ({response.StatusCode}: {body})");
            }

            _logger.LogInformation("Contact email sent successfully to {ToAddress}", toAddress);
        }
        catch (Exception ex) when (ex is not SendEmailException)
        {
            _logger.LogError(ex, "Error sending contact email");
            throw new SendEmailException("Failed to send email", ex);
        }
    }
}

public class SendEmailException : Exception
{
    public SendEmailException()
    {
    }

    public SendEmailException(string message) : base(message)
    {
    }

    public SendEmailException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

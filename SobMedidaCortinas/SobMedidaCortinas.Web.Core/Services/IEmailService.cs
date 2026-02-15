using SobMedidaCortinas.Web.Core.Models;

namespace SobMedidaCortinas.Web.Core.Services;

public interface IEmailService
{
    Task SendContactEmailAsync(ContactModel contactData);
}

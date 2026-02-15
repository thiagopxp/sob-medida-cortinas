using System.ComponentModel.DataAnnotations;

namespace SobMedidaCortinas.Web.Core.Models;

public class ContactModel
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefone é obrigatório")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mensagem é obrigatória")]
    public string Mensagem { get; set; } = string.Empty;

    public string Bairro { get; set; } = string.Empty;
}

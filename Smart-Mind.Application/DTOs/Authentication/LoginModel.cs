using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Authentication
{
    public class LoginModel
    {
            
        [Required(ErrorMessage = "User-Name obrigatório")]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha obrigatória")]
        public string? Senha { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Nome de usuário obrigatório")]
        public string? Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; } = string.Empty;

        [Required(ErrorMessage ="O sobrenome é obrigatório")]
        public string? Sobrenome { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail obrigatório")]
        [Required]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obrigatório")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não coincidem.")]
        public string? ConfirmarSenha { get; set; } = string.Empty;

        [Required(ErrorMessage ="A idade é obrigatória")]
        public int Idade { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Request
{
    public class RespostaUsuarioDTO
    {
        [Required(ErrorMessage= "O Id do usuário é obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage ="O Id da alternativa é obrigatório")]
        public int AlternativaId { get; set; }

        [Required(ErrorMessage ="é preciso fornecer a variável booleana")]
        public bool Acertou { get; set; }
    }
}

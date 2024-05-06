using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Request
{
    public class TesteRequest
    {

        [Required(ErrorMessage = "O nome do teste é obrigatório")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage ="A data é obrigatória")]
        public DateTime DataDaRealizacao { get; set; }

        [Required(ErrorMessage = "A pontuação é obrigatória")]
        public int Pontuacao { get; set; }

        [Required(ErrorMessage = "A pontuação do usuário é obrigatória")]
        public int PontuacaoUsuario { get; set; }

        [Required(ErrorMessage = "Id do usuário é obrigatório")]
        public int UsuarioId { get; set; }

        [Required]
        public ICollection<int> QuestoesId { get; set; } = null!;
    }
}

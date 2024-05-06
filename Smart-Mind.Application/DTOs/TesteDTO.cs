using Smart_Mind.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Smart_Mind.Application.DTOs
{
    public class TesteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do teste é obrigatório")]
        public string Nome { get; set; } = null!;

        [Required]
        public DateTime DataDaRealizacao { get; set; }  

        [Required]
        public int Pontuacao { get; set; } 

        [Required]
        public int PontuacaoUsuario { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore]
        public ICollection<int> QuestoesId { get; set; } = null!;

        public ICollection<Questao> Questoes { get; set; } = null!;
    }
}

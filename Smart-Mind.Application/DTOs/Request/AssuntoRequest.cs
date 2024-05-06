using Smart_Mind.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Smart_Mind.Application.DTOs.Request
{
    public class AssuntoRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O Link é obrigatório")]
        public string VideoAulaUrl { get; set; } = null!;

        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "O id da matéria é obrigatório")]
        public int MateriaId { get; set; }

        [JsonIgnore]
        public Materia? Materia { get; set; }

        [JsonIgnore]
        public ICollection<Questao>? Questoes { get; set; } 
    }
}

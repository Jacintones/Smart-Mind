using Smart_Mind.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Smart_Mind.Application.DTOs
{
    public class MateriaDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string ImagemUrl { get; set; } = null!;

        [Required]
        public int CategoriaId { get; set; } 

        [JsonIgnore]
        public ICollection<AssuntoDTO> Assuntos { get; set; } = [];

    }
}

using Smart_Mind.Application.DTOs.Response;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Smart_Mind.Application.DTOs.Request
{
    public class MateriaRequest
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string ImagemUrl { get; set; } = null!;

        [Required]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public ICollection<AssuntoResponse> Assuntos { get; set; } = [];
    }
}

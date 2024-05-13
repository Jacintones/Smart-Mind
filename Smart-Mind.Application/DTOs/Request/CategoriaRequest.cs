using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Smart_Mind.Application.DTOs.Request
{
    public class CategoriaRequest
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; } = null!;

        [JsonIgnore]
        public ICollection<MateriaRequest>? Materias { get; set; }
    }
}

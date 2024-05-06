using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Smart_Mind.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]    
        public string Nome { get; set; } = null!;

        [JsonIgnore]
        public ICollection<MateriaDTO> Materias { get; set; } = null!;
    }
}

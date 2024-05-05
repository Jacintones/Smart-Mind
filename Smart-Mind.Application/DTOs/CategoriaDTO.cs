using System.ComponentModel.DataAnnotations;


namespace Smart_Mind.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]    
        public string? Nome { get; set; }

        public ICollection<MateriaDTO>? Materias { get; set; }
    }
}

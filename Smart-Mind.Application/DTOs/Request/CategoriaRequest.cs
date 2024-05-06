using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Request
{
    public class CategoriaRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;
    }
}

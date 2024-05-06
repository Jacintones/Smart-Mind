using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Request
{
    public class AssuntoRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O Link é obrigatório")]
        public string VideoAulaUrl { get; set; } = null!;

        public string ImagemUrl { get; set; } = null!;

        [Required(ErrorMessage = "O id da matéria é obrigatório")]
        public int MateriaId { get; set; }
    }
}

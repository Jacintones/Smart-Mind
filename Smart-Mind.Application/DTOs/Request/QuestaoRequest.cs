using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Request
{
    public class QuestaoRequest
    {
        [Required(ErrorMessage = "Enunciado é obrigatório")]
        public string Enunciado { get; set; } = null!;

        public string? ImagemUrl { get; set; } 

        [Required(ErrorMessage = "Alternativa correta é obrigatória")]
        public string AlternativaCorreta { get; set; } = null!;

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string AlternativaErrada1 { get; set; } = null!;

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string AlternativaErrada2 { get; set; } = null!;

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string AlternativaErrada3 { get; set; } = null!;

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string AlternativaErrada4 { get; set; } = null!;

        [Required(ErrorMessage = "A dificuldade é obrigatória")]
        [AllowedValues("F", "M", "D")]
        public string Dificuldade { get; set; } = null!;

        [Required]
        public int AssuntoId { get; set; }
    }
}

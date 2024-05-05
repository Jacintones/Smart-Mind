using System.ComponentModel.DataAnnotations;


namespace Smart_Mind.Application.DTOs
{
    public class QuestaoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enunciado é obrigatório")]
        public string? Enunciado { get; set; }

        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "Alternativa correta é obrigatória")]
        public string? AlternativaCorreta { get; set; }

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string? AlternativaErrada1 { get; set; }

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string? AlternativaErrada2 { get; set; }

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string? AlternativaErrada3 { get; set; }

        [Required(ErrorMessage = "Alternativa Errada é obrigatória")]
        public string? AlternativaErrada4 { get; set; }

        [Required(ErrorMessage = "A dificuldade é obrigatória")]
        [AllowedValues("F", "M", "D")]
        public string? Dificuldade { get; set; }

        [Required]
        public int AssuntoId { get; set; }
    }
}

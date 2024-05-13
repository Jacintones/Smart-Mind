using Smart_Mind.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Request
{
    public class QuestaoRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enunciado é obrigatório")]
        public string Enunciado { get; set; } = null!;

        public string? ImagemUrl { get; set; } 

        [Required(ErrorMessage = "A dificuldade é obrigatória")]
        [AllowedValues("F", "M", "D")]
        public string Dificuldade { get; set; } = null!;

        //Pode ser nulo
        public ExplicacaoDTO? Explicacao { get; set; } 

        public List<AlternativaDTO> Alternativas { get; set; } = [];

        [Required]
        public int AssuntoId { get; set; }
    }
}

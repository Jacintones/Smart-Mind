using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Response
{
    public class QuestaoResponse
    {
        public int Id { get; set; }

        public string Enunciado { get; set; } = null!;

        public string ImagemUrl { get; set; } = null!;

        public string AlternativaCorreta { get; set; } = null!;

        public string AlternativaErrada1 { get; set; } = null!;

        public string AlternativaErrada2 { get; set; } = null!;

        public string AlternativaErrada3 { get; set; } = null!;

        public string AlternativaErrada4 { get; set; } = null!;

        public string Dificuldade { get; set; } = null!;

        public int AssuntoId { get; set; }
    }
}

using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Response
{
    public class QuestaoResponse
    {
        public int Id { get; set; }

        public string Enunciado { get; set; } = null!;

        public string? ImagemUrl { get; set; }

        public string Dificuldade { get; set; } = null!;

        public ExplicacaoDTO? Explicacao { get; set; }

        public List<AlternativaDTO> Alternativas { get; set; } = [];

        public int AssuntoId { get; set; }
    }
}

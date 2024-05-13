
namespace Smart_Mind.Application.DTOs.Request
{
    public class ExplicacaoDTO
    {
        public int Id { get; set; }

        public string Texto { get; set; } = string.Empty;

        public string? Imagem { get; set; } = string.Empty;

        public int QuestaoId { get; set; }
    }
}


namespace Smart_Mind.Application.DTOs.Request
{
    public class ExplicacaoAssuntoRequest
    {
        public int Id { get; set; }

        public string Texto { get; set; } = string.Empty;

        public string? Imagem { get; set; }

        public int AssuntoId { get; set; }

    }
}

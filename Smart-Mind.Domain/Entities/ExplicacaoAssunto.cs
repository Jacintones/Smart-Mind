
namespace Smart_Mind.Domain.Entities
{
    public class ExplicacaoAssunto : Entity
    {
        public string Texto { get; set; } = string.Empty;

        public string? Imagem { get; set; } 

        public int AssuntoId { get; set; }

        public Assunto Assunto { get; set; } = null!;
    }
}

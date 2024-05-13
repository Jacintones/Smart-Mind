

namespace Smart_Mind.Domain.Entities
{
    public class Questao : Entity
    {
        public string Enunciado { get; set; } = null!;

        public string? ImagemUrl { get; set; } 

        public string Dificuldade { get; set; } = null!;

        public int AssuntoId { get; set; }

        public Assunto Assunto { get; set; } = null!;

        public Explicacao? Explicacao { get; set; } 

        public ICollection<Alternativa> Alternativas { get; set; } = [];

        public ICollection<Teste> Testes { get; set; } = [];
    }
}


namespace Smart_Mind.Domain.Entities
{
    public class Explicacao : Entity
    {
        public string Texto { get; set; } = string.Empty;

        public string? Imagem { get; set; } = string.Empty;

        public int QuestaoId { get; set; } 

        public Questao Questao { get; set; } = null!;

    }
}

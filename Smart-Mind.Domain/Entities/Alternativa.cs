
namespace Smart_Mind.Domain.Entities
{
    public class Alternativa : Entity
    {
        public string Texto { get; set; } = null!;

        public bool Correta { get; set; }

        public int QuestaoId { get; set; }

        public Questao Questao { get; set; } = null!;
    }
}

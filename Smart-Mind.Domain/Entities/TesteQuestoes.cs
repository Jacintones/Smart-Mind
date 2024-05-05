
namespace Smart_Mind.Domain.Entities
{
    public class TesteQuestoes
    {
        public int TesteId { get; set; }
        public Teste Teste { get; set; }
     
        public int QuestaoId { get; set; }
        public Questao Questao { get; set; }
    }
}

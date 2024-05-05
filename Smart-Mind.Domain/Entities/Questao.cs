

namespace Smart_Mind.Domain.Entities
{
    public class Questao : Entity
    {
        public Questao(string? enunciado, string? alternativaCorreta, 
            string? alternativaErrada1, string? alternativaErrada2, string? 
            alternativaErrada3, string? alternativaErrada4, string? dificuldade, int assuntoId)
        {
            Enunciado = enunciado;
            AlternativaCorreta = alternativaCorreta;
            AlternativaErrada1 = alternativaErrada1;
            AlternativaErrada2 = alternativaErrada2;
            AlternativaErrada3 = alternativaErrada3;
            AlternativaErrada4 = alternativaErrada4;
            Dificuldade = dificuldade;
            AssuntoId = assuntoId;
        }

        public Questao(string? enunciado, string? imagemUrl, 
            string? alternativaCorreta, string? alternativaErrada1, string? alternativaErrada2, 
            string? alternativaErrada3, string? alternativaErrada4, string? dificuldade, int assuntoId)
        {
            Enunciado = enunciado;
            ImagemUrl = imagemUrl;
            AlternativaCorreta = alternativaCorreta;
            AlternativaErrada1 = alternativaErrada1;
            AlternativaErrada2 = alternativaErrada2;
            AlternativaErrada3 = alternativaErrada3;
            AlternativaErrada4 = alternativaErrada4;
            Dificuldade = dificuldade;
            AssuntoId = assuntoId;
        }

        public string? Enunciado { get; set; }

        public string? ImagemUrl { get; set; }

        public string? AlternativaCorreta { get; set; }

        public string? AlternativaErrada1 { get; set; }

        public string? AlternativaErrada2 { get; set; }

        public string? AlternativaErrada3 { get; set; }

        public string? AlternativaErrada4 { get; set; }

        public string? Dificuldade { get; set; }

        public int AssuntoId { get; set; }

        public Assunto? Assunto { get; set; }

        public ICollection<Teste> Testes { get; set; }
    }
}

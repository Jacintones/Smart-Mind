
namespace Smart_Mind.Domain.Entities
{
    public class Assunto : Entity
    {
        public Assunto(string nome, string videoAulaUrl, int materiaId)
        {
            Nome = nome;
            VideoAulaUrl = videoAulaUrl;
            MateriaId = materiaId;
        }

        public string Nome { get; set; } = null!;

        public string VideoAulaUrl { get; set; } = null!;

        public int MateriaId { get; set; } 

        public Materia Materia { get; set; } = null!;

        public ICollection<Questao> Questoes { get; set; } = [];

        public ICollection<Explicacao> Explicacoes { get; set; } = [];
    }
}

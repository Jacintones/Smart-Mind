

namespace Smart_Mind.Domain.Entities
{
    public class Materia : Entity
    {
        public Materia(string nome, string imagemUrl, int categoriaId)
        {
            Nome = nome;
            ImagemUrl = imagemUrl;
            CategoriaId = categoriaId;
        }

        public string Nome { get; set; } = null!;

        public string ImagemUrl { get; set; } = null!;

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; } = null!;

        public ICollection<Assunto> Assuntos { get; set; } = null!;
    }
}

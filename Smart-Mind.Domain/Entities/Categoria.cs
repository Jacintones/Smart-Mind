

namespace Smart_Mind.Domain.Entities
{
    public class Categoria : Entity
    {
        public Categoria(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; } = null!;

        public ICollection<Materia> Materias { get; set; } = null!;
    }
}

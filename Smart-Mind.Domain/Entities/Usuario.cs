
namespace Smart_Mind.Domain.Entities
{
    public class Usuario : Entity
    {

        public string Login { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string Sobrenome { get; set; } = null!;

        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public int Idade { get; set; } 

        public string? ImagemUrl { get; set; } 

        public ICollection<Teste> Testes { get; set; } = [];

    }
}

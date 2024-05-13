
namespace Smart_Mind.Domain.Entities
{
    public class RespostaUsuario : Entity
    {
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public int AlternativaId { get; set; }

        public bool Acertou { get; set; } 

        public Alternativa Alternativa { get; set; } = null!;
    }
}

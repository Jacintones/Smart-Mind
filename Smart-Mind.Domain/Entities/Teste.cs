namespace Smart_Mind.Domain.Entities
{
    public class Teste : Entity
    {
        public string Nome { get; private set; } = null!;

        public DateTime DataDaRealizacao { get; private set; }

        public int Pontuacao { get; private set; }

        public int PontuacaoUsuario { get; private set; }

        public int UsuarioId { get; private set; }

        public Usuario Usuario { get; private set; } = null!;

        public ICollection<Questao> Questoes { get; private set; } = [];

        public ICollection<RespostaUsuario> RespostaUsuarios { get; private set; } = [];
    }
}

namespace Smart_Mind.Domain.Entities
{
    public class Teste : Entity
    {
        public Teste(string? nome, DateTime? dataDaRealizacao, int? pontuacao, int? pontuacaoUsuario, int usuarioId)
        {
            Nome = nome;
            DataDaRealizacao = dataDaRealizacao;
            Pontuacao = pontuacao;
            PontuacaoUsuario = pontuacaoUsuario;
            UsuarioId = usuarioId;
        }

        public string? Nome { get;private set; }

        public DateTime? DataDaRealizacao { get; private set; }

        public int? Pontuacao { get; set; }

        public int? PontuacaoUsuario { get; private set; }

        public int UsuarioId { get; private set; }

        public Usuario Usuario { get; private set; }

        public ICollection<Questao>? Questoes { get; private set; }
    }
}

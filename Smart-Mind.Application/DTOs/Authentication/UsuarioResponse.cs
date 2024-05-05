
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.Application.DTOs.Authentication
{
    public class UsuarioResponse
    {
        public string? Login { get; set; }

        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }

        public string? NomeCompleto { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public int Idade { get; set; }

        public string? ImagemUrl { get; set; }

        public ICollection<Teste>? Testes { get; set; }
    }
}

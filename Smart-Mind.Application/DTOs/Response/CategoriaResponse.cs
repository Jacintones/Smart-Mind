
using Smart_Mind.Application.DTOs.Request;

namespace Smart_Mind.Application.DTOs.Response
{
    public class CategoriaResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public ICollection<MateriaRequest> Materias { get; set; } = null!;
    }
}

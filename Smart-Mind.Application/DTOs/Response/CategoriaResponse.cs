
namespace Smart_Mind.Application.DTOs.Response
{
    public class CategoriaResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public ICollection<MateriaDTO> Materias { get; set; } = null!;
    }
}

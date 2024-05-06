using Smart_Mind.Domain.Entities;

namespace Smart_Mind.Application.DTOs.Response
{
    public class MateriaResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string ImagemUrl { get; set; } = null!;

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; } = null!;

        public ICollection<AssuntoDTO> Assuntos { get; set; } = null!;
    }
}

using Smart_Mind.Domain.Entities;
using System.Text.Json.Serialization;

namespace Smart_Mind.Application.DTOs.Response
{
    public class MateriaResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string ImagemUrl { get; set; } = null!;

        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; } = null!;

        public ICollection<AssuntoResponse> Assuntos { get; set; } = null!;
    }
}

using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs.Response
{
    public class MateriaResponse
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? ImagemUrl { get; set; }

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        public ICollection<Assunto>? Assuntos { get; set; }
    }
}

using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs.Response
{
    public class ExplicacaoAssuntoResponse
    {
        public int Id { get; set; }

        public string Texto { get; set; } = string.Empty;

        public string? Imagem { get; set; }

        public int AssuntoId { get; set; }
        
    }
}

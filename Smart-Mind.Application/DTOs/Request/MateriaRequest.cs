using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs.Request
{
    public class MateriaRequest
    {

        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string ImagemUrl { get; set; } = null!;

        [Required]
        public int CategoriaId { get; set; }

    }
}

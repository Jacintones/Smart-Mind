using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs
{
    public class AssuntoDTO
    {
        public int  Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Link é obrigatório")]
        public string VideoAulaUrl { get; set; }

        public string? ImagemUrl { get; set; }


        [Required(ErrorMessage = "O id da matéria é obrigatório")]
        public int MateriaId { get; set; }

    }
}

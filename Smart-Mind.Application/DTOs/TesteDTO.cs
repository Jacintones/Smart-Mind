using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs
{
    public class TesteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do teste é obrigatório")]
        public string? Nome { get; set; }

        [Required]
        public DateTime? DataDaRealizacao { get; set; }

        [Required]
        public int? Pontuacao { get; set; }

        [Required]
        public int? PontuacaoUsuario { get; set; }

        public int UsuarioId { get; set; }

        public List<int> IdQuestoes { get; set; }
    }
}

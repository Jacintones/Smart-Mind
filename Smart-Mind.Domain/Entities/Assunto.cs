using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Smart_Mind.Domain.Entities
{
    public class Assunto : Entity
    {
        public Assunto(string? nome, string? videoAulaUrl, int materiaId)
        {
            Nome = nome;
            VideoAulaUrl = videoAulaUrl;
            MateriaId = materiaId;
        }

        public string? Nome { get; set; }

        public string? VideoAulaUrl { get; set; }

        public string? ImagemUrl { get; set; }

        public int MateriaId { get; set; }

        public Materia Materia { get; set; }

        public ICollection<Questao> Questoes { get; set; }
    }
}

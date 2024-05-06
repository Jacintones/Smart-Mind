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
        public Assunto(string nome, string videoAulaUrl, int materiaId)
        {
            Nome = nome;
            VideoAulaUrl = videoAulaUrl;
            MateriaId = materiaId;
            Questoes = new List<Questao>();
        }

        public string Nome { get; set; } = null!;

        public string VideoAulaUrl { get; set; } = null!;

        public string ImagemUrl { get; set; } = null!;

        public int MateriaId { get; set; } 

        public Materia Materia { get; set; } = null!;

        public ICollection<Questao> Questoes { get; set; } = null!;
    }
}

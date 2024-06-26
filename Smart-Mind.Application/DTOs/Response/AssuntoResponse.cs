﻿using Smart_Mind.Domain.Entities;
using System.Text.Json.Serialization;

namespace Smart_Mind.Application.DTOs.Response
{
    public class AssuntoResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string VideoAulaUrl { get; set; } = null!;

        public int MateriaId { get; set; }

        [JsonIgnore]
        public Materia? Materia { get; set; }

        public ICollection<QuestaoResponse> Questoes { get; set; } = null!;
    }
}

﻿
using Smart_Mind.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Smart_Mind.Application.DTOs.Response
{
    public class TesteResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public DateTime DataDaRealizacao { get; set; } 

        public int Pontuacao { get; set; }

        public int PontuacaoUsuario { get; set; }

        public int UsuarioId { get; set; }

        public ICollection<QuestaoDTO> Questoes { get; set; } = null!;
    }
}
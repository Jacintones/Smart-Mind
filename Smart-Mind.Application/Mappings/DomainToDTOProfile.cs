using AutoMapper;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Authentication;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Mappings
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<AssuntoDTO, Assunto>().ReverseMap();
            CreateMap<AssuntoDTO, AssuntoResponse>().ReverseMap();
            CreateMap<AssuntoDTO, AssuntoRequest>().ReverseMap();

            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<CategoriaDTO, CategoriaRequest>().ReverseMap();
            CreateMap<CategoriaDTO, CategoriaResponse>().ReverseMap();
            CreateMap<Categoria, CategoriaResponse>().ReverseMap();
            CreateMap<CategoriaRequest, Categoria>().ReverseMap();

            CreateMap<MateriaDTO, Materia>().ReverseMap();
            CreateMap<MateriaDTO, MateriaResponse>().ReverseMap();
            CreateMap<MateriaDTO, MateriaRequest>().ReverseMap();

            CreateMap<QuestaoDTO, Questao>().ReverseMap();
            CreateMap<QuestaoDTO, QuestaoRequest>().ReverseMap();
            CreateMap<QuestaoDTO, QuestaoResponse>().ReverseMap();

            CreateMap<TesteDTO,TesteResponse>().ReverseMap();
            CreateMap<TesteDTO, Teste>().ReverseMap();
            CreateMap<TesteDTO, TesteRequest>().ReverseMap();
            CreateMap<TesteRequest, Teste>().ReverseMap();

            CreateMap<Usuario, LoginModel>().ReverseMap();
            CreateMap<Usuario, RegisterModel>().ReverseMap();
        }
    }
}

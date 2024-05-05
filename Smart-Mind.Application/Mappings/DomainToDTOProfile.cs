using AutoMapper;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Authentication;
using Smart_Mind.Application.DTOs.Request;
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
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<CategoriaDTO, CategoriaRequest>().ReverseMap();
            CreateMap<CategoriaRequest, Categoria>().ReverseMap();
            CreateMap<MateriaDTO, Materia>().ReverseMap();
            CreateMap<QuestaoDTO, Questao>().ReverseMap();
            CreateMap<TesteDTO, Teste>().ReverseMap();

            CreateMap<Usuario, LoginModel>().ReverseMap();
            CreateMap<Usuario, RegisterModel>().ReverseMap();
        }
    }
}

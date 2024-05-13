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
            CreateMap<Alternativa, AlternativaDTO>().ReverseMap();

            CreateMap<Assunto, AssuntoRequest >().ReverseMap();
            CreateMap<Assunto, AssuntoResponse>().ReverseMap();

            CreateMap<Categoria, CategoriaResponse>().ReverseMap();
            CreateMap<Categoria, CategoriaRequest>().ReverseMap();

            CreateMap<Materia, MateriaResponse>().ReverseMap();
            CreateMap<Materia, MateriaRequest>().ReverseMap();

            CreateMap<Questao, QuestaoRequest >().ReverseMap();
            CreateMap<Questao, QuestaoResponse>().ReverseMap();

            CreateMap<Teste, TesteResponse>().ReverseMap();
            CreateMap<Teste, TesteRequest>().ReverseMap();

            CreateMap<RespostaUsuario, RespostaUsuarioDTO>().ReverseMap();

            CreateMap<ExplicacaoAssunto, ExplicacaoAssuntoRequest>().ReverseMap();
            CreateMap<ExplicacaoAssunto, ExplicacaoAssuntoResponse>().ReverseMap();

            CreateMap<Explicacao, ExplicacaoDTO>().ReverseMap();    

            CreateMap<Usuario, LoginModel>().ReverseMap();
            CreateMap<Usuario, RegisterModel>().ReverseMap();
        }
    }
}

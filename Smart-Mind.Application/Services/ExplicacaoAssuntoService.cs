using AutoMapper;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;

namespace Smart_Mind.Application.Services
{
    public class ExplicacaoAssuntoService : IExplicacaoAssuntoService
    {
        private readonly IExplicacaoAssuntoRepositorio _repositorio;

        private readonly IMapper _mapper;

        public ExplicacaoAssuntoService(IExplicacaoAssuntoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task Add(ExplicacaoAssuntoRequest request)
        {
            //Converto o dto para o formato padrão de dados
            var explicacao = _mapper.Map<ExplicacaoAssunto>(request);

            //Chamo o método do repositório que cria a instância
            await _repositorio.Create(explicacao);

            //Seto o id afim de informar no response
            request.Id = explicacao.Id;
        }

        public async Task<IEnumerable<ExplicacaoAssuntoResponse>> GetAll()
        {
            var explicacoes = await _repositorio.GetAll();

            return _mapper.Map<IEnumerable<ExplicacaoAssuntoResponse>>(explicacoes);
        }

        public async Task<ExplicacaoAssuntoResponse> GetById(int id)
        {
            var explicacao = await _repositorio.GetById(id);

            return _mapper.Map<ExplicacaoAssuntoResponse>(explicacao);
        }

        public async Task Remove(int id)
        {
            var explicacao = _repositorio.GetById(id).Result;

            await _repositorio.Delete(explicacao);
        }

        public async Task Update(ExplicacaoAssuntoRequest request)
        {
            var explicacao = _mapper.Map<ExplicacaoAssunto>(request);

            await _repositorio.Update(explicacao);
        }
    }
}

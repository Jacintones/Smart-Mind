using AutoMapper;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;

namespace Smart_Mind.Application.Services
{
    public class AssuntoService : IAssuntoService
    {

        private IAssuntoRepository _assuntoRepository;

        private readonly IMapper _mapper;

        public AssuntoService(IAssuntoRepository assuntoRepository, IMapper mapper)
        {
            _assuntoRepository = assuntoRepository;
            _mapper = mapper;
        }

        public async Task Add(AssuntoRequest request)
        {
            //Converto o dto para o formato padrão de dados
            var assunto = _mapper.Map<Assunto>(request); 

            //Chamo o método do repositório que cria a instância
            await _assuntoRepository.Create(assunto);

            //Seto o id afim de informar no response
            request.Id = assunto.Id;
        }

        public async Task<IEnumerable<AssuntoResponse>> GetAll()
        {
            var assuntos = await _assuntoRepository.GetAll();

            return _mapper.Map<IEnumerable<AssuntoResponse>>(assuntos);
        }

        public async Task<AssuntoResponse> GetById(int id)
        {
            var assunto = await _assuntoRepository.GetById(id);

            return _mapper.Map<AssuntoResponse>(assunto);
        }

        public async Task Remove(int id)
        {
            var assunto = _assuntoRepository.GetById(id).Result;

            await _assuntoRepository.Delete(assunto);
        }

        public async Task Update(AssuntoRequest request)
        {
            var assunto = _mapper.Map<Assunto>(request);

            await _assuntoRepository.Update(assunto);
        }
    }
}

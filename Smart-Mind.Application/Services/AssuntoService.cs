using AutoMapper;
using Smart_Mind.Application.DTOs;
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

        public async Task Add(AssuntoDTO assuntoDTO)
        {
            var assunto = _mapper.Map<Assunto>(assuntoDTO); 

            await _assuntoRepository.Create(assunto);
        }

        public async Task<IEnumerable<AssuntoDTO>> GetAll()
        {
            var assuntos = await _assuntoRepository.GetAll();

            return _mapper.Map<IEnumerable<AssuntoDTO>>(assuntos);
        }

        public async Task<AssuntoDTO> GetById(int id)
        {
            var assunto = await _assuntoRepository.GetById(id);

            return _mapper.Map<AssuntoDTO>(assunto);
        }

        public async Task Remove(int id)
        {
            var assunto = _assuntoRepository.GetById(id).Result;

            await _assuntoRepository.Delete(assunto);
        }

        public async Task Update(AssuntoDTO assuntoDTO)
        {
            var assunto = _mapper.Map<Assunto>(assuntoDTO);

            await _assuntoRepository.Update(assunto);
        }
    }
}

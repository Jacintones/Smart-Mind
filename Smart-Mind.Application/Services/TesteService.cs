using AutoMapper;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;

namespace Smart_Mind.Application.Services
{
    public class TesteService : ITesteService
    {
        private ITesteRepository _testeRepository;

        private readonly IMapper _mapper;

        public TesteService(ITesteRepository testeRepository, IMapper mapper)
        {
            _testeRepository = testeRepository;
            _mapper = mapper;
        }

        public async Task Add(TesteDTO testeDTO)
        {
            var teste = _mapper.Map<Teste>(testeDTO);

            await _testeRepository.Create(teste);

            testeDTO.Id = teste.Id;
        }

        public async Task<IEnumerable<TesteDTO>> GetAll()
        {
            var testes = await _testeRepository.GetAll();

            return _mapper.Map<IEnumerable<TesteDTO>>(testes);
        }

        public async Task<TesteDTO> GetById(int id)
        {
            var teste = await _testeRepository.GetById(id);

            return _mapper.Map<TesteDTO>(teste);
        }

        public async Task Remove(int id)
        {
            var teste = _testeRepository.GetById(id).Result;

            await _testeRepository.Delete(teste);
        }

        public async Task Update(TesteDTO testeDTO)
        {
            var teste = _mapper.Map<Teste>(testeDTO);

            await _testeRepository.Update(teste);
        }
    }
}

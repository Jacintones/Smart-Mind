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

        private IQuestaoRepository  _questaoRepository;

        private readonly IMapper _mapper;

        public TesteService(ITesteRepository testeRepository, IMapper mapper, IQuestaoRepository questaoRepository)
        {
            _testeRepository = testeRepository;
            _mapper = mapper;
            _questaoRepository = questaoRepository;
        }

        public async Task Add(TesteDTO testeDTO)
        {
            var teste = _mapper.Map<Teste>(testeDTO);

            if (testeDTO.QuestoesId != null && testeDTO.QuestoesId.Count != 0)
            {
                foreach (int questaoId in testeDTO.QuestoesId)
                {
                    // Aqui você pode buscar a questão no banco de dados usando o ID
                    var questao = await _questaoRepository.GetById(questaoId);

                    if (questao != null)
                    {
                        // Adiciona a questão ao teste
                        teste.Questoes.Add(questao);
                    }
                }
            }

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

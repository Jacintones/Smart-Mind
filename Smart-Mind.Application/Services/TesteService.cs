using AutoMapper;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
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

        public async Task Add(TesteRequest request)
        {
            var teste = _mapper.Map<Teste>(request);

            foreach (int questaoId in request.QuestoesId)
            {
                // Aqui você pode buscar a questão no banco de dados usando o ID
                var questao = await _questaoRepository.GetById(questaoId);

                if (questao != null)
                {
                    // Adiciona a questão ao teste
                    teste.Questoes.Add(questao);
                }
            }
            
            await _testeRepository.Create(teste);

            request.Id = teste.Id;
        }

        public async Task<IEnumerable<TesteResponse>> GetAll()
        {
            var testes = await _testeRepository.GetAll();

            return _mapper.Map<IEnumerable<TesteResponse>>(testes);
        }

        public async Task<TesteResponse> GetById(int id)
        {
            var teste = await _testeRepository.GetById(id);

            return _mapper.Map<TesteResponse>(teste);
        }

        public async Task Remove(int id)
        {
            var teste = _testeRepository.GetById(id).Result;

            await _testeRepository.Delete(teste);
        }

        public async Task Update(TesteRequest request)
        {
            var teste = _mapper.Map<Teste>(request);

            await _testeRepository.Update(teste);
        }
    }
}

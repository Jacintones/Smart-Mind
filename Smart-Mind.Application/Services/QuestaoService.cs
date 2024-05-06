using AutoMapper;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;

namespace Smart_Mind.Application.Services
{
    public class QuestaoService : IQuestaoService
    {
        private IQuestaoRepository _questaoRepository;

        private readonly IMapper _mapper;

        public QuestaoService(IQuestaoRepository questaoRepository, IMapper mapper)
        {
            _questaoRepository = questaoRepository;
            _mapper = mapper;
        }

        public async Task Add(QuestaoRequest request)
        {
            var questao = _mapper.Map<Questao>(request);

            await _questaoRepository.Create(questao);

            request.Id = questao.Id;
        }

        public async Task<IEnumerable<QuestaoResponse>> GetAll()
        {
            var questoes = await _questaoRepository.GetAll();

            return _mapper.Map<IEnumerable<QuestaoResponse>>(questoes);
        }

        public async Task<QuestaoResponse> GetById(int id)
        {
            var questao = await _questaoRepository.GetById(id);

            return _mapper.Map<QuestaoResponse>(questao);
        }

        public async Task Remove(int id)
        {
            var questao = _questaoRepository.GetById(id).Result;

            await _questaoRepository.Delete(questao);
        }

        public async Task Update(QuestaoRequest request)
        {
            var questao = _mapper.Map<Questao>(request);

            await _questaoRepository.Update(questao);
        }
    }
}

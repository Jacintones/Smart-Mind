using AutoMapper;
using Smart_Mind.Application.DTOs;
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

        public async Task Add(QuestaoDTO questaoDTO)
        {
            var questao = _mapper.Map<Questao>(questaoDTO);

            await _questaoRepository.Create(questao);

            questaoDTO.Id = questao.Id;
        }

        public async Task<IEnumerable<QuestaoDTO>> GetAll()
        {
            var questoes = await _questaoRepository.GetAll();

            return _mapper.Map<IEnumerable<QuestaoDTO>>(questoes);
        }

        public async Task<QuestaoDTO> GetById(int id)
        {
            var questao = await _questaoRepository.GetById(id);

            return _mapper.Map<QuestaoDTO>(questao);
        }

        public async Task Remove(int id)
        {
            var questao = _questaoRepository.GetById(id).Result;

            await _questaoRepository.Delete(questao);
        }

        public async Task Update(QuestaoDTO questaoDTO)
        {
            var questao = _mapper.Map<Questao>(questaoDTO);

            await _questaoRepository.Update(questao);
        }
    }
}

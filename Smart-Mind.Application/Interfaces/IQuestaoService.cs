using Smart_Mind.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Interfaces
{
    public interface IQuestaoService
    {
        Task<IEnumerable<QuestaoDTO>> GetAll();

        Task<QuestaoDTO> GetById(int id);

        Task Add(QuestaoDTO questaoDTO);

        Task Update(QuestaoDTO questaoDTO);

        Task Remove(int id);
    }
}

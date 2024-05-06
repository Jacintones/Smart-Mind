using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Interfaces
{
    public interface IQuestaoService
    {
        Task<IEnumerable<QuestaoResponse>> GetAll();

        Task<QuestaoResponse> GetById(int id);

        Task Add(QuestaoRequest request);

        Task Update(QuestaoRequest request);

        Task Remove(int id);
    }
}

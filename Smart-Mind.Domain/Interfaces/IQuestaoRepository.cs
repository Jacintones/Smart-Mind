using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Domain.Interfaces
{
    public interface IQuestaoRepository
    {
        Task<ICollection<Questao>> GetAll();

        Task<Questao> GetById(int id);

        Task<Questao> Create(Questao questao);

        Task<Questao> Update(Questao questao);

        Task Delete(Questao questao);
    }
}

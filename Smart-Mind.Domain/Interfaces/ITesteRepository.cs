using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Domain.Interfaces
{
    public interface ITesteRepository
    {
        Task<ICollection<Teste>> GetAll();

        Task<Teste> GetById(int id);

        Task<ICollection<Teste>> GetTesteWithQuestoes();

        Task<Teste> Create(Teste teste);

        Task<Teste> Update(Teste teste);

        Task<Teste> Delete(Teste teste);
    }
}

using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Domain.Interfaces
{
    public interface IAssuntoRepository
    {
        Task<ICollection<Assunto>> GetAll();

        Task<Assunto> GetById(int id);

        Task<Assunto> Create(Assunto assunto);

        Task<Assunto> Update(Assunto assunto);

        Task Delete(Assunto assunto);
    }
}

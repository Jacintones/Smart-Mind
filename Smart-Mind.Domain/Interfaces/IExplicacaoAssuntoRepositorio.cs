using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Domain.Interfaces
{
    public interface IExplicacaoAssuntoRepositorio
    {
        Task<ICollection<ExplicacaoAssunto>> GetAll();

        Task<ExplicacaoAssunto> GetById(int id);

        Task<ExplicacaoAssunto> Create(ExplicacaoAssunto explicacaoAssunto);

        Task<ExplicacaoAssunto> Update(ExplicacaoAssunto explicacaoAssunto);

        Task<ExplicacaoAssunto> Delete(ExplicacaoAssunto explicacaoAssunto);
    }
}

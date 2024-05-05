using Smart_Mind.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Interfaces
{
    public interface ITesteService
    {
        Task<IEnumerable<TesteDTO>> GetAll();

        Task<TesteDTO> GetById(int id);

        Task Add(TesteDTO testeDTO);

        Task Update(TesteDTO testeDTO);

        Task Remove(int id);
    }
}

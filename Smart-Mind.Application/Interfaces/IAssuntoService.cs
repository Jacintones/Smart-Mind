using Smart_Mind.Application.DTOs;
using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Interfaces
{
    public interface IAssuntoService
    {
        Task<IEnumerable<AssuntoDTO>> GetAll();

        Task<AssuntoDTO> GetById(int id);

        Task Add(AssuntoDTO assuntoDTO);

        Task Update(AssuntoDTO AssuntoDTO);

        Task Remove(int id);
    }
}

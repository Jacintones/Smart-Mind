using Smart_Mind.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Interfaces
{
    public interface IMateriaService
    {
        Task<IEnumerable<MateriaDTO>> GetAll();

        Task<MateriaDTO> GetById(int id);

        Task Add(MateriaDTO materiaDTO);

        Task Update(MateriaDTO materiaDTO);

        Task Remove(int id);
    }
}

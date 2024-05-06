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
    public interface IMateriaService
    {
        Task<IEnumerable<MateriaResponse>> GetAll();

        Task<MateriaResponse> GetById(int id);

        Task Add(MateriaRequest request);

        Task Update(MateriaRequest request);

        Task Remove(int id);
    }
}

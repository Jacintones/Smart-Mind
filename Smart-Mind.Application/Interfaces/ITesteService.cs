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
    public interface ITesteService
    {
        Task<IEnumerable<TesteResponse>> GetAll();

        Task<TesteResponse> GetById(int id);

        Task Add(TesteRequest testeRequest);

        Task Update(TesteRequest testeRequest);

        Task Remove(int id);
    }
}

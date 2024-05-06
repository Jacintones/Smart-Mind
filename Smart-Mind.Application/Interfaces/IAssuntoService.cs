using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
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
        Task<IEnumerable<AssuntoResponse>> GetAll();

        Task<AssuntoResponse> GetById(int id);

        Task Add(AssuntoRequest request);

        Task Update(AssuntoRequest request);

        Task Remove(int id);
    }
}

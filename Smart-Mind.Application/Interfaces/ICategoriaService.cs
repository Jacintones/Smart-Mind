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
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaResponse>> GetAll();

        Task<CategoriaResponse> GetById(int id);

        Task<ICollection<CategoriaResponse>> GetCategoriasWithMaterias();

        Task Add(CategoriaRequest request);

        Task Update(CategoriaRequest request);

        Task Remove(int id);
    }
}

using Smart_Mind.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAll();

        Task<CategoriaDTO> GetById(int id);

        Task<ICollection<CategoriaDTO>> GetCategoriasWithMaterias();

        Task Add(CategoriaDTO categoriaDTO);

        Task Update(CategoriaDTO categoriaDTO);

        Task Remove(int id);
    }
}

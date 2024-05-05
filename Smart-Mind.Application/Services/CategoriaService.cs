using AutoMapper;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;

namespace Smart_Mind.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;

        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            await _categoriaRepository.Create(categoria);

            categoriaDTO.Id = categoria.Id;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            var categorias = await _categoriaRepository.GetAll(); 

            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);  

        }

        public async Task<CategoriaDTO> GetById(int id)
        {
            var categoria = await _categoriaRepository.GetById(id);
        
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task Remove(int id)
        {
            var categoryEntity = _categoriaRepository.GetById(id).Result;
            
            await _categoriaRepository.Delete(categoryEntity);
        }

        public async Task Update(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            await _categoriaRepository.Update(categoria);
        }

        public async Task<ICollection<CategoriaDTO>> GetCategoriasWithMaterias()
        {
            var categorias = await _categoriaRepository.GetCategoriaWithMateria();

            return _mapper.Map<ICollection<CategoriaDTO>>(categorias);
        }
    }
}

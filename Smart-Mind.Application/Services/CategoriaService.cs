using AutoMapper;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
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

        public async Task Add(CategoriaRequest request)
        {
            var categoria = _mapper.Map<Categoria>(request);

            await _categoriaRepository.Create(categoria);

            request.Id = categoria.Id;
        }

        public async Task<IEnumerable<CategoriaResponse>> GetAll()
        {
            var categorias = await _categoriaRepository.GetAll(); 

            return _mapper.Map<IEnumerable<CategoriaResponse>>(categorias);  

        }

        public async Task<CategoriaResponse> GetById(int id)
        {
            var categoria = await _categoriaRepository.GetById(id);
        
            return _mapper.Map<CategoriaResponse>(categoria);
        }

        public async Task Remove(int id)
        {
            var categoryEntity = _categoriaRepository.GetById(id).Result;
            
            await _categoriaRepository.Delete(categoryEntity);
        }

        public async Task Update(CategoriaRequest request)
        {
            var categoria = _mapper.Map<Categoria>(request);

            await _categoriaRepository.Update(categoria);
        }

        public async Task<ICollection<CategoriaResponse>> GetCategoriasWithMaterias()
        {
            var categorias = await _categoriaRepository.GetCategoriaWithMateria();

            return _mapper.Map<ICollection<CategoriaResponse>>(categorias);
        }
    }
}

using AutoMapper;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;

namespace Smart_Mind.Application.Services
{
    public class MateriaService : IMateriaService
    {
        private IMateriaRepository _materiaRepository;

        private readonly IMapper _mapper;

        public MateriaService(IMateriaRepository materiaRepository, IMapper mapper)
        {
            _materiaRepository = materiaRepository;
            _mapper = mapper;
        }

        public async Task Add(MateriaRequest request)
        {
            var materia = _mapper.Map<Materia>(request);

            await _materiaRepository.Create(materia);

            request.Id = materia.Id;
        }

        public async Task<IEnumerable<MateriaResponse>> GetAll()
        {
            var materias = await _materiaRepository.GetAll();

            return _mapper.Map<IEnumerable<MateriaResponse>>(materias);
        }

        public async Task<MateriaResponse> GetById(int id)
        {
            var materia = await _materiaRepository.GetById(id);

            return _mapper.Map<MateriaResponse>(materia);
        }

        public async Task Remove(int id)
        {
            var materia = _materiaRepository.GetById(id).Result;

            await _materiaRepository.Delete(materia);
        }

        public async Task Update(MateriaRequest request)
        {
            var materia = _mapper.Map<Materia>(request);

            await _materiaRepository.Update(materia);
        }
    }
}

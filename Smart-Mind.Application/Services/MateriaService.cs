using AutoMapper;
using Smart_Mind.Application.DTOs;
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

        public async Task Add(MateriaDTO materiaDTO)
        {
            var materia = _mapper.Map<Materia>(materiaDTO);

            await _materiaRepository.Create(materia);

            materiaDTO.Id = materia.Id;
        }

        public async Task<IEnumerable<MateriaDTO>> GetAll()
        {
            var materias = await _materiaRepository.GetAll();

            return _mapper.Map<IEnumerable<MateriaDTO>>(materias);
        }

        public async Task<MateriaDTO> GetById(int id)
        {
            var materia = await _materiaRepository.GetById(id);

            return _mapper.Map<MateriaDTO>(materia);
        }

        public async Task Remove(int id)
        {
            var materia = _materiaRepository.GetById(id).Result;

            await _materiaRepository.Delete(materia);
        }

        public async Task Update(MateriaDTO materiaDTO)
        {
            var materia = _mapper.Map<Materia>(materiaDTO);

            await _materiaRepository.Update(materia);
        }
    }
}

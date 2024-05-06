using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;

        private readonly IMapper _mapper;

        public MateriaController(IMateriaService materiaService, IMapper mapper)
        {
            _materiaService = materiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaDTO>>> GetAll()
        {
            var materias = await _materiaService.GetAll();

            return Ok(materias);
        }

        [HttpGet("{id:int}", Name = "GetMateria")]
        public async Task<ActionResult<MateriaResponse>> GetById(int id)
        {
            var materia = await _materiaService.GetById(id);

            var response = _mapper.Map<MateriaResponse>(materia);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MateriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var materiaDto = _mapper.Map<MateriaDTO>(request);

            await _materiaService.Add(materiaDto);

            return new CreatedAtRouteResult("GetMateria",
                new { id = materiaDto.Id }, materiaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MateriaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != dto.Id)
            {
                return BadRequest();
            }
            await _materiaService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Materia>> Delete(int id)
        {
            var dto = await _materiaService.GetById(id);

            if (dto == null)
            {
                return NotFound();
            }

            await _materiaService.Remove(id);

            return Ok(dto);
        }
    }
}

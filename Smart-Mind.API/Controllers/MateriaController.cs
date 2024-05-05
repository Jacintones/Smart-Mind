using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Application.Services;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;

        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaDTO>>> GetAll()
        {
            var materias = await _materiaService.GetAll();

            return Ok(materias);
        }

        [HttpGet("{id:int}", Name = "GetMaterias")]
        public async Task<ActionResult<MateriaDTO>> GetById(int id)
        {
            var materia = await _materiaService.GetById(id);

            return Ok(materia);
        }

        [HttpPost]
        public async Task<ActionResult<MateriaDTO>> Create([FromBody] MateriaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _materiaService.Add(dto);

            return new CreatedAtRouteResult("GetMaterias",
                new { id = dto.Id }, dto);
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

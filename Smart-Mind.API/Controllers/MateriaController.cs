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

        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaResponse>>> GetAll()
        {
            var materias = await _materiaService.GetAll();

            return Ok(materias);
        }

        [HttpGet("{id:int}", Name = "GetMateria")]
        public async Task<ActionResult<MateriaResponse>> GetById(int id)
        {
            var materia = await _materiaService.GetById(id);

            return Ok(materia);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MateriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _materiaService.Add(request);

            return new CreatedAtRouteResult("GetMateria",
                new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MateriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _materiaService.Update(request);

            return Ok(request);
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

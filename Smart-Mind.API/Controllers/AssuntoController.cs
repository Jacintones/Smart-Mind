using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Application.Services;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntoController(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssuntoDTO>>> GetAll()
        {
            var assuntos = await _assuntoService.GetAll();

            return Ok(assuntos);
        }

        [HttpGet("{id:int}", Name = "GetAssunto")]
        public async Task<ActionResult<AssuntoDTO>> GetById(int id)
        {
            var assunto = await _assuntoService.GetById(id);

            return Ok(assunto);
        }

        [HttpPost]
        public async Task<ActionResult<AssuntoDTO>> Create([FromBody] AssuntoDTO assuntoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _assuntoService.Add(assuntoDTO);

            return new CreatedAtRouteResult("GetAssunto",
                new { id = assuntoDTO.Id }, assuntoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AssuntoDTO>> Update(int id, AssuntoDTO assuntoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assuntoDTO.Id)
            {
                return BadRequest();
            }

            await _assuntoService.Update(assuntoDTO);

            return Ok(assuntoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AssuntoDTO>> Delete(int id)
        {
            var assunto = await _assuntoService.GetById(id);

            if (assunto == null)
            {
                return NotFound();
            }

            await _assuntoService.Remove(id);

            return Ok(assunto);
        }
    }
}

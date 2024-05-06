using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponse>>> Get()
        {
            var categorias = await _categoriaService.GetAll();

            return Ok(categorias);

        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<CategoriaResponse>> Get(int id)
        {
            var categoria = await _categoriaService.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpGet]
        [Route("CategoriaComMateria")]
        public async Task<ActionResult<IEnumerable<CategoriaResponse>>> GetWithMateria()
        {
            var categorias = await _categoriaService.GetCategoriasWithMaterias();

            return Ok(categorias);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoriaService.Add(request);

            return new CreatedAtRouteResult("GetCategoria",
                new { id = request.Id }, request);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _categoriaService.Update(request);

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoriaDto = await _categoriaService.GetById(id);
            
            if (categoriaDto == null)
            {
                return NotFound();
            }

            await _categoriaService.Remove(id);

            return Ok(categoriaDto);
        }
    }
}

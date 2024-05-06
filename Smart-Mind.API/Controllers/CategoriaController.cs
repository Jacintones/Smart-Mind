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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
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

            var response = _mapper.Map<CategoriaResponse>(categoria);

            return Ok(response);
        }

        [HttpGet]
        [Route("CategoriaComMateria")]
        public async Task<ActionResult<IEnumerable<CategoriaResponse>>> GetWithMateria()
        {
            var categorias = await _categoriaService.GetCategoriasWithMaterias();

            var response = _mapper.Map<IEnumerable<CategoriaResponse>>(categorias);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(request);  

            await _categoriaService.Add(categoriaDto);

            return new CreatedAtRouteResult("GetCategoria",
                new { id = categoriaDto.Id }, categoriaDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != categoriaDto.Id)
            {
                return BadRequest();
            }
            await _categoriaService.Update(categoriaDto);

            return Ok(categoriaDto);
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

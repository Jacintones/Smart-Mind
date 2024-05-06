using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Application.Services;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;

        private readonly IMapper _mapper;

        public AssuntoController(IAssuntoService assuntoService, IMapper mapper)
        {
            _assuntoService = assuntoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssuntoResponse>>> GetAll()
        {
            var assuntos = await _assuntoService.GetAll();

            var response = _mapper.Map<IEnumerable<AssuntoResponse>>(assuntos);

            return Ok(response);
        }

        [HttpGet("{id:int}", Name = "GetAssunto")]
        public async Task<ActionResult<AssuntoResponse>> GetById(int id)
        {
            var assunto = await _assuntoService.GetById(id);

            if (assunto == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<AssuntoResponse>(assunto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AssuntoRequest request)
        {
            //Verifico se é válido, se não for, retorno um badrequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Converto o request para DTO
            var assuntoDTO = _mapper.Map<AssuntoDTO>(request);

            //Chamo a camada de serviços passando o dto de forma assíncrona
            await _assuntoService.Add(assuntoDTO);

            //Retorna a rota 201
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

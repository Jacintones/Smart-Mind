using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Application.Services;
using Smart_Mind.Domain.Entities;

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
        public async Task<ActionResult<IEnumerable<AssuntoResponse>>> GetAll()
        {
            //Pega todos os assuntos do service
            var assuntos = await _assuntoService.GetAll();

            //Retorna Ok
            return Ok(assuntos);
        }

        [HttpGet("{id:int}", Name = "GetAssunto")]
        public async Task<ActionResult<AssuntoResponse>> GetById(int id)
        {
            var assunto = await _assuntoService.GetById(id);

            if (assunto == null)
            {
                return NotFound();
            }

            return Ok(assunto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AssuntoRequest request)
        {
            //Verifico se é válido, se não for, retorno um badrequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Chamo a camada de serviços passando o dto de forma assíncrona
            await _assuntoService.Add(request);

            //Retorna a rota 201
            return new CreatedAtRouteResult("GetAssunto",
                new { id = request.Id }, request);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, AssuntoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            await _assuntoService.Update(request);

            return Ok(request);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Assunto>> Delete(int id)
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

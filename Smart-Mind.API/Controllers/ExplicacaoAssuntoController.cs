using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Application.Services;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExplicacaoAssuntoController : ControllerBase
    {
        private readonly IExplicacaoAssuntoService _service;

        public ExplicacaoAssuntoController(IExplicacaoAssuntoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExplicacaoAssuntoResponse>>> GetAll()
        {
            var explicacoes = await _service.GetAll();

            return Ok(explicacoes);
        }

        [HttpGet("{id:int}", Name = "GetExplicacao")]
        public async Task<ActionResult<ExplicacaoAssuntoResponse>> GetById(int id)
        {
            var explicacao = await _service.GetById(id);

            if (explicacao == null)
            {
                return NotFound();
            }

            return Ok(explicacao);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ExplicacaoAssuntoRequest request)
        {
            //Verifico se é válido, se não for, retorno um badrequest
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Chamo a camada de serviços passando o dto de forma assíncrona
            await _service.Add(request);

            //Retorna a rota 201
            return new CreatedAtRouteResult("GetExplicacao",
                new { id = request.Id }, request);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, ExplicacaoAssuntoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            await _service.Update(request);
            return Ok(request);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ExplicacaoAssuntoResponse>> Delete(int id)
        {
            var explicacao = await _service.GetById(id);

            if (explicacao == null)
            {
                return NotFound();
            }

            await _service.Remove(id);

            return Ok(explicacao);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly ITesteService _testeService;

        public TesteController(ITesteService testeService)
        {
            _testeService = testeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TesteResponse>>> Get()
        {
            var testes = await _testeService.GetAll();
            return Ok(testes);

        }

        [HttpGet("{id}", Name = "GetTeste")]
        public async Task<ActionResult<TesteResponse>> Get(int id)
        {
            var teste = await _testeService.GetById(id);

            if (teste == null)
            {
                return NotFound();
            }

            return Ok(teste);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TesteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _testeService.Add(request);

            return new CreatedAtRouteResult("GetTeste",
                new { id = request.Id }, request);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TesteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _testeService.Update(request);

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teste>> Delete(int id)
        {
            var teste = await _testeService.GetById(id);

            if (teste == null)
            {
                return NotFound();
            }

            await _testeService.Remove(id);

            return Ok(teste);
        }
    }
}

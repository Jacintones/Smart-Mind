using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.Interfaces;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TesteController : ControllerBase
    {
        private ITesteService _testeService;

        public TesteController(ITesteService testeService)
        {
            _testeService = testeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TesteDTO>>> Get()
        {
            var testes = await _testeService.GetAll();
            return Ok(testes);

        }

        [HttpGet("{id}", Name = "GetTeste")]
        public async Task<ActionResult<TesteDTO>> Get(int id)
        {
            var teste = await _testeService.GetById(id);

            if (teste == null)
            {
                return NotFound();
            }
            return Ok(teste);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TesteDTO testeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _testeService.Add(testeDTO);

            return new CreatedAtRouteResult("GetTeste",
                new { id = testeDTO.Id }, testeDTO);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TesteDTO testeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != testeDTO.Id)
            {
                return BadRequest();
            }
            await _testeService.Update(testeDTO);

            return Ok(testeDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TesteDTO>> Delete(int id)
        {
            var testeDTO = await _testeService.GetById(id);

            if (testeDTO == null)
            {
                return NotFound();
            }

            await _testeService.Remove(id);

            return Ok(testeDTO);
        }
    }
}

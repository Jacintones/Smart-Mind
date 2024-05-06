using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;
using Smart_Mind.Application.Interfaces;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly ITesteService _testeService;

        private readonly IMapper _mapper;

        public TesteController(ITesteService testeService, IMapper mapper)
        {
            _testeService = testeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TesteDTO>>> Get()
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

            var response = _mapper.Map<TesteResponse>(teste);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TesteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _mapper.Map<TesteDTO>(request);

            await _testeService.Add(dto);

            return new CreatedAtRouteResult("GetTeste",
                new { id = dto.Id }, dto);
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

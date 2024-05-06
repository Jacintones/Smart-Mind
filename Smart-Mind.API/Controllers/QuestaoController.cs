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
    public class QuestaoController : ControllerBase
    {
        private readonly IQuestaoService _questaoService;

        private readonly IMapper _mapper;

        public QuestaoController(IQuestaoService questaoService, IMapper mapper)
        {
            _questaoService = questaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestaoResponse>>> GetAll()
        {
            var questoes = await _questaoService.GetAll();

            var response = _mapper.Map<IEnumerable<QuestaoResponse>>(questoes);

            return Ok(response);
        }

        [HttpGet("{id:int}", Name = "GetQuestao")]
        public async Task<ActionResult<QuestaoResponse>> GetById(int id)
        {
            var questao = await _questaoService.GetById(id);

            var response = _mapper.Map<QuestaoResponse>(questao);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(QuestaoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _mapper.Map<QuestaoDTO>(request);

            await _questaoService.Add(dto);

            return new CreatedAtRouteResult("GetQuestao",
                new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] QuestaoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != dto.Id)
            {
                return BadRequest();
            }

            await _questaoService.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var questao = await _questaoService.GetById(id);

            if (questao == null)
            {
                return NotFound();
            }

            await _questaoService.Remove(id);

            return Ok(questao);
        }
    }
}

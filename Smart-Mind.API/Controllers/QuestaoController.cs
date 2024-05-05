using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestaoController : ControllerBase
    {
        private readonly IQuestaoService _questaoService;

        public QuestaoController(IQuestaoService questaoService)
        {
            _questaoService = questaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestaoDTO>>> GetAll()
        {
            var questoes = await _questaoService.GetAll();

            return Ok(questoes);
        }

        [HttpGet("{id:int}", Name = "GetQuestao")]
        public async Task<ActionResult<QuestaoDTO>> GetById(int id)
        {
            var questao = await _questaoService.GetById(id);

            return Ok(questao);
        }

        [HttpPost]
        public async Task<ActionResult<QuestaoDTO>> Create(QuestaoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

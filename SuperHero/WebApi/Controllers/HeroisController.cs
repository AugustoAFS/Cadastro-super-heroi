using ApplicationService.Dtos.Requests.Heroi;
using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IHeroiService _heroiService;

        public HeroisController(IHeroiService heroiService)
        {
            _heroiService = heroiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var herois = await _heroiService.GetAllAAssync();
            return Ok(herois);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var heroi = await _heroiService.GetByIdAsync(id);
            return Ok(heroi);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHeroiRequest request)
        {
            var heroi = await _heroiService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = heroi.Id }, heroi);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHeroiRequest request)
        {
            var heroi = await _heroiService.UpdateAsync(id, request);
            return Ok(heroi);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _heroiService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Super-herói com Id {id} não encontrado para exclusão.");
            }
            return Ok("Super-herói excluído com sucesso.");
        }
    }
}

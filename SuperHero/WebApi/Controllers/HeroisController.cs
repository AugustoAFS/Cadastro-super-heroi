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
            var response = await _heroiService.GetAllAAssync();
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _heroiService.GetByIdAsync(id);
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, new { message = response.Message, statusCode = response.StatusCode });
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHeroiRequest request)
        {
            var response = await _heroiService.CreateAsync(request);
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, new { message = response.Message, statusCode = response.StatusCode });
            }
            return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHeroiRequest request)
        {
            var response = await _heroiService.UpdateAsync(id, request);
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, new { message = response.Message, statusCode = response.StatusCode });
            }
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _heroiService.DeleteAsync(id);
             if (!response.Success)
            {
                return StatusCode(response.StatusCode, new { message = response.Message, statusCode = response.StatusCode });
            }
            return Ok("Super-herói excluído com sucesso.");
        }
    }
}

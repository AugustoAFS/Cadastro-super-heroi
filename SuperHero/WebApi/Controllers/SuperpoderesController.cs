using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderesController : ControllerBase
    {
        private readonly ISuperpoderService _superpoderService;

        public SuperpoderesController(ISuperpoderService superpoderService)
        {
            _superpoderService = superpoderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _superpoderService.GetAllAsync();
            return Ok(response.Data);
        }
    }
}

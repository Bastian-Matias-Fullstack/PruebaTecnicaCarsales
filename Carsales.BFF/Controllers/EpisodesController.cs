using Carsales.BFF.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carsales.BFF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly IRickAndMortyService _service;
        public EpisodesController(IRickAndMortyService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> GetEpisodes([FromQuery] int page = 1)
        {
            if (page < 1)
                return BadRequest("El número de página debe ser mayor a 0.");

            var result = await _service.GetEpisodesAsync(page);

            if (result == null)
                return StatusCode(502, "Error al consumir la API externa.");

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchEpisodes([FromQuery] string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Debe proporcionar un nombre para buscar.");

            var result = await _service.SearchEpisodesAsync(name);

            return Ok(result);
        }

    }
}

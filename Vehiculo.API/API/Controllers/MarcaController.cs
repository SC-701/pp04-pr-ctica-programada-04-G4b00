using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase, IMarcaController
    {
        private readonly IMarcaFlujo _marcaFlujo;
        private ILogger<MarcaController> _logger;

        public MarcaController(IMarcaFlujo marcaFlujo, ILogger<MarcaController> logger)
        {
            _marcaFlujo = marcaFlujo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var result = await _marcaFlujo.Obtener();
            if(!result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}

using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase, IModeloController
    {
        private IModeloFlujo _modeloFlujo;
        private ILogger<ModeloController> _logger;

        public ModeloController(IModeloFlujo modeloFlujo, ILogger<ModeloController> logger)
        {
            _modeloFlujo = modeloFlujo;
            _logger = logger;
        }

        [HttpGet("{IdMarca}")]
        public async Task<IActionResult> Obtener(Guid IdMarca)
        {
            var result = await _modeloFlujo.Obtener(IdMarca);
            if (!result.Any())
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}

using GestionServicios.Application.Contratacion.CreateContratacion;
using GestionServicios.Application.Contratacion.GetContrataciones;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratacionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContratacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateContratacion([FromBody] CreateContratacionCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return Ok(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, "Se registro correctamente");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetContrataciones()
        {
            try
            {
                var result = await _mediator.Send(new GetContratacionesQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

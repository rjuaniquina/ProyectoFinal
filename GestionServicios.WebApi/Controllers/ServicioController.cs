
using GestionServicios.Application.Servicios.GetServicios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionServicios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : Controller
    {
        private readonly IMediator _mediator;

        public ServicioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> GetServicios()
        {
            try
            {
                var result = await _mediator.Send(new GetServiciosQuery(""));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
    
}

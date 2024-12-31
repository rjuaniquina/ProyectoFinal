
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Contratacion.CreateContratacion
{
    public record CreateContratacionCommand(Guid id, Guid paciente_id, Guid servicio_id, DateTime fecha_contratacion, int duracion, string estado, Decimal total) : IRequest<Guid>;
    
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Contratacion.GetContrataciones
{
    public record GetContratacionesQuery(string SearchTerm):IRequest<IEnumerable<ContratacionDto>>;
  
}

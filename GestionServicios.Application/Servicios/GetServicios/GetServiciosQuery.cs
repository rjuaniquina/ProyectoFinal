using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Servicios.GetServicios;

public record GetServiciosQuery(string SearchTerm) : IRequest<IEnumerable<ServicioDto>>;

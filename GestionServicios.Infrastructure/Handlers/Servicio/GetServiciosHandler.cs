using GestionServicios.Application.Servicios.GetServicios;
using GestionServicios.Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.Handlers.Servicios;

internal class GetServiciosHandler : IRequestHandler<GetServiciosQuery, IEnumerable<ServicioDto>>
{
    private readonly StoredDbContext _dbContext;

    public GetServiciosHandler(StoredDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ServicioDto>> Handle(GetServiciosQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Servicio.AsNoTracking().
            Select(s => new ServicioDto()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Costo = s.Costo
            }).
             ToListAsync(cancellationToken);
    }

}

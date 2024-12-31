using GestionServicios.Application.Contratacion.GetContrataciones;
using GestionServicios.Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastucture.Handlers.Contratacion
{
    internal class GetContratacionesHandler: IRequestHandler<GetContratacionesQuery, IEnumerable<ContratacionDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetContratacionesHandler(StoredDbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ContratacionDto>> Handle(GetContratacionesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Contratacion.AsNoTracking().
                Select(static c => new ContratacionDto()
                { 
                    Id = c.Id,
                    Paciente_Id = c.PacienteId,
                    Servicio_Id = c.ServicioId,
                    Fecha_Contratacion = c.FechaContratacion,
                    Duracion=c.Duracion,
                    Estado=c.Estado,
                    Total=c.Total,

                }).
                ToListAsync(cancellationToken);
        }
       
    }
}

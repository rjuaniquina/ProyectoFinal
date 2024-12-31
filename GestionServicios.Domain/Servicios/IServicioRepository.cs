using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Contrataciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios
{
    public interface IServicioRepository : IRepository<Servicio>
    {
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(Guid id);
    }
}

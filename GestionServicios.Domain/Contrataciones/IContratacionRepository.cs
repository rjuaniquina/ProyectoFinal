using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Contrataciones
{
    public interface IContratacionRepository : IRepository<Contratacion>
    {
        Task UpdateAsync(Contratacion contratacion);
        Task DeleteAsync(Guid id);
    }
}

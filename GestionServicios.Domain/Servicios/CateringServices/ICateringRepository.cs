using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios.CateringServices
{
    public interface ICateringRepository
    {
        Task UpdateAsync(Catering catering);
        Task DeleteAsync(Guid id);
    }
}

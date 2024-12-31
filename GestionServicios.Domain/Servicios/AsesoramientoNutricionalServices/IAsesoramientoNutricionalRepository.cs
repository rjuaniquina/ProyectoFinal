using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios.AsesoramientoNutricionalServices
{
    public interface IAsesoramientoNutricionalRepository
    {
        Task UpdateAsync(AsesoramientoNutricional asesoramientoNutricional);
        Task DeleteAsync(Guid id);
    }
}

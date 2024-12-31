using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios.AsesoramientoNutricionalServices
{
    public interface IAsesoramientoNutricionalFactory
    {
        AsesoramientoNutricional Create(Guid id, string especialista, string tipoplan, string modalidad, int duracion_dias);
    }
}

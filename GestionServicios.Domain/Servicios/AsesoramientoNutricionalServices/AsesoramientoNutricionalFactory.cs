using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionServicios.Domain.Servicios.AsesoramientoNutricionalServices
{
    public class AsesoramientoNutricionalFactory : IAsesoramientoNutricionalFactory
    {
        public AsesoramientoNutricional Create(Guid id, string especialista, string tipoplan, string modalidad, int duracion_dias)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id es requerido", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(especialista))
            {
                throw new ArgumentException("especialista es requerido", nameof(especialista));
            }

            if (string.IsNullOrWhiteSpace(tipoplan))
            {
                throw new ArgumentException("tipoplan es requerido", nameof(tipoplan));
            }
            if (string.IsNullOrWhiteSpace(modalidad))
            {
                throw new ArgumentException("modalidad es requerido", nameof(modalidad));
            }
            if (int.IsNegative(duracion_dias))
            {
                throw new ArgumentException("duracion_dias no puede ser negativo", nameof(duracion_dias));
            }

            return new AsesoramientoNutricional(id, especialista, tipoplan, modalidad,duracion_dias);
        }
    }
}

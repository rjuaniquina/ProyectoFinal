using GestionServicios.Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionServicios.Domain.Contrataciones
{
    public class ContratacionFactory : IContratacionFactory
    {
        public Contratacion Create(Guid id, Guid paciente_id, Guid servicio_id, DateTime fecha_contratacion, int duracion, string estado,decimal total)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id es requerido", nameof(id));
            }
            if (paciente_id == Guid.Empty)
            {
                throw new ArgumentException("paciente_id es requerido", nameof(paciente_id));
            }
            if (servicio_id == Guid.Empty)
            {
                throw new ArgumentException("servicio_id es requerido", nameof(servicio_id));
            }
            if (int.IsNegative(duracion))
            {
                throw new ArgumentException("duracion no puede ser negativo", nameof(duracion));
            }
            if (string.IsNullOrWhiteSpace(estado))
            {
                throw new ArgumentException("estado es requerido", nameof(estado));
            }
            if (Decimal.IsNegative(total))
            {
                throw new ArgumentException("total no puede ser negativo", nameof(total));
            }

            return new Contratacion(id, paciente_id,servicio_id,fecha_contratacion ,duracion, estado,total);
        }
    }
}

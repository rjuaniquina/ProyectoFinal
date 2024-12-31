using GestionServicios.Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios
{
    public class ServicioFactory : IServicioFactory
    {
        public Servicio Create(Guid id, string nombre, string descripcion ,string estado)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id es requerido", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("nombre servicio es requerido", nameof(nombre));
            }

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("descripcion del servicio es requerido", nameof(nombre));
            }
            if (string.IsNullOrWhiteSpace(estado))
            {
                throw new ArgumentException("estado del servicio es requerido", nameof(nombre));
            }

            return new Servicio(id, nombre, descripcion, estado);
        }

    }
}

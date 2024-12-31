using GestionServicios.Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios
{
    public interface IServicioFactory
    {
        Servicio Create(Guid id, string nombre, string descripcion, String estado);
    }
}

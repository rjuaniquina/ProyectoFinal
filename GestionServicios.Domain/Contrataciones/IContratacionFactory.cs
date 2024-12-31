using GestionServicios.Domain.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Contrataciones
{
    public interface IContratacionFactory
    {
        Contratacion Create(Guid id, Guid paciente_id, Guid servicio_id, DateTime fecha_contratacion, int duracion,string estado, Decimal total);
    }
}

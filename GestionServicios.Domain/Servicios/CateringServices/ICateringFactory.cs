using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios.CateringServices
{
    public interface ICateringFactory
    {
        Catering Create(Guid id, string tipocomida, int duracion, Boolean incluyebebidas);
    }
}


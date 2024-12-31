using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Pacientes
{
    public interface IPacienteFactory
    {
        Paciente Create(Guid id, string nombre, DateTime fechanac, Double peso, Double altura, string composicioncorporal);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Pacientes
{
    public class PacienteFactory : IPacienteFactory
    {
        public Paciente Create(Guid id, string nombre, DateTime fechanac, double peso, double altura, string composicioncorporal)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id es requerido", nameof(id));
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("nombre paciente es requerido", nameof(nombre));
            }
            if (Double.IsNegative(peso))
            {
                throw new ArgumentException("peso del paciente no puede ser negativo", nameof(peso));
            }
            if (Double.IsNegative(altura))
            {
                throw new ArgumentException("altura del paciente no puede ser negativo", nameof(altura));
            }
            if (string.IsNullOrWhiteSpace(composicioncorporal))
            {
                throw new ArgumentException("composicioncorporal del paciente es requerido", nameof(composicioncorporal));
            }
            return new Paciente(id, nombre,fechanac,peso,altura,composicioncorporal);
        }
    }
}

using GestionServicios.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Pacientes
{
    public interface IPacienteRepository:IRepository<Paciente>
    {
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Contratacion.GetContrataciones
{
    public class ContratacionDto
    {
        public Guid Id { get; set; }
        public Guid Paciente_Id { get;  set; }
        public Guid Servicio_Id { get; set; }
        public DateTime Fecha_Contratacion { get;set; }
        public int Duracion { get; set; }
        public string Estado { get; set; }
        public Decimal Total { get; set; }
    }
}

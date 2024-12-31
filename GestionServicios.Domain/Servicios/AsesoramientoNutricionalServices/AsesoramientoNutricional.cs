using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios.AsesoramientoNutricionalServices
{
    public class AsesoramientoNutricional:Servicio
    {
        public string Especialista { get; private set; }
        public string TipoPlan { get; private set; }
        public string Modalidad { get; private set; }
        public int Duracion_dias { get; private set; }
        public AsesoramientoNutricional(Guid id, string especialista, string tipoplan, string modalidad, int duracion_dias) : base(id)
        {
            Especialista = especialista;
            TipoPlan = tipoplan;
            Modalidad = modalidad;
            Duracion_dias = duracion_dias;
        }
        private AsesoramientoNutricional() { }
    }
}

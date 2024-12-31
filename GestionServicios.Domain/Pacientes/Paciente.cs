using GestionServicios.Domain.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionServicios.Domain.Pacientes
{
    public class Paciente : AggregateRoot
    {
        public string Nombre { get; private set; }
        public DateTime FechaNac { get; private set; }
        public Double Peso { get; private set; }
        public Double Altura { get; private set; }
        public String ComposicionCorporal { get; private set; }
        //public IEnumerable <ServicioDto>  { get; set; }
       

        public Paciente(Guid id, string nombre,DateTime fechanac ,double peso, double altura, string composicioncorporal) : base(id)
        {
            Nombre = nombre;
            FechaNac = fechanac;
            Peso = peso;
            Altura = altura;
            ComposicionCorporal = composicioncorporal;
        }
    }
}

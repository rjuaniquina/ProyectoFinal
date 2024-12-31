using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios
{
    public class Servicio:AggregateRoot
    {
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public CostValue Costo { get; private set; }
        public string Estado { get; private set; }
        public Servicio(Guid id, string nombre, string descripcion, String estado) : base(id)
        {           
            Nombre = nombre;
            Descripcion = descripcion;                     
            Estado = estado;
        }
        public Servicio() { }

        public Servicio(Guid id) : base(id)
        {
        }
    }
}

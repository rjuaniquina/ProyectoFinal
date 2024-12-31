using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionServicios.Domain.Contrataciones
{
    public class Contratacion:AggregateRoot
    {
        public Guid Paciente_Id { get; private set; }
        public Guid Servicio_Id { get; private set; }
        public DateTime Fecha_Contratacion { get; private set; }
        public int Duracion { get; private set; }
        public string Estado { get; private set; }
        public Decimal Total { get; private set; }
        public Contratacion(Guid id, Guid paciente_id,Guid servicio_id ,DateTime fecha_contratacion, int duracion,string estado, Decimal total) : base(id)
        {
            Paciente_Id = paciente_id;
            Servicio_Id = servicio_id;
            Fecha_Contratacion = fecha_contratacion;
            Duracion = duracion;
            Estado = estado;
            Total = total;
        }
        public Contratacion() { }
        public void ActualizarEstado(Guid Id, string estado)
        {
            if (Estado == "En Proceso")
            {
                Estado = estado;
            }           
        }
      
    }
}

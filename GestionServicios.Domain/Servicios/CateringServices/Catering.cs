using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Servicios;
using GestionServicios.Domain.Shared;
using GestionServicios.Domain.Servicios.CateringServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Servicios.CateringServices
{
    public class Catering:Servicio
    {       
        public string TipoComida { get; private set; }   
        public int Duracion { get; private set; }
        public Boolean IncluyeBebidas { get; private set; }
        public Catering(Guid id,string tipocomida, int duracion, Boolean incluyebebidas) : base(id)
        {
            TipoComida = tipocomida;
            Duracion = duracion;
            IncluyeBebidas = incluyebebidas;           
        }
        private Catering() { }
    }
}

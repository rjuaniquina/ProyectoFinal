using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.StoredModel.Entities
{
    [Table("contrataciones")]

    internal class ContratacionStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("paciente_id")]
        public Guid PacienteId { get; set; }

        [Column("servicio_id")]
        public Guid ServicioId { get; set; }

        [Column("fecha_contratacion")]        
        [Required]
        public DateTime FechaContratacion { get; set; }       

        [Column("duracion")]
        [Required]      
        public int Duracion { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; }

        [Column("total", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Total { get; set; }
    }
}

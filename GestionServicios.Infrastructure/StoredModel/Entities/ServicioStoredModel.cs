using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.StoredModel.Entities
{
    [Table("servicios")]
    internal class ServicioStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("costo", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Costo { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; }

      
    }
}

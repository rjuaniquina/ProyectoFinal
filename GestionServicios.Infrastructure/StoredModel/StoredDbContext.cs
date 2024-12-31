using GestionServicios.Infrastructure.StoredModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.StoredModel
{
    internal class StoredDbContext : DbContext
    {
        public DbSet<ServicioStoredModel> Servicio { get; set; }
        public DbSet<ContratacionStoredModel> Contratacion { get; set; }
        public DbSet<TransactionStoredModel> Transaction { get; set; }
        public DbSet<TransactionContratacionStoredModel> TransactionContratacion { get; set; }
        public DbSet<UserStoredModel> User { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {

        }

    }
}

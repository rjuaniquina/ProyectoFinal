using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Contrataciones;
using GestionServicios.Domain.Servicios;
using GestionServicios.Domain.Transactions;
using GestionServicios.Domain.Transactions.Events;
using GestionServicios.Domain.Users;
using GestionServicios.Infrastructure.StoredModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.DomainModel
{
    internal class DomainDbContext : DbContext
    {
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Contratacion> Contratacion { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> User { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<TransactionCompleted>();
        }
    }
}

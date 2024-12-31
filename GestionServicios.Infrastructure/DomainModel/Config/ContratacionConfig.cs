using GestionServicios.Domain.Contrataciones;
using GestionServicios.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.DomainModel.Config
{
    internal class ContratacionConfig : IEntityTypeConfiguration<Contratacion>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contratacion> builder)
        {
            builder.ToTable("contrataciones");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Paciente_Id)
                   .HasColumnName("id");

            builder.Property(x => x.Paciente_Id)
                .HasColumnName("paciente_id");

            builder.Property(x => x.Servicio_Id)
               .HasColumnName("servicio_id");

            builder.Property(x => x.Fecha_Contratacion)
                .HasColumnName("fecha_contratacion");

            builder.Property(x => x.Duracion)
               .HasColumnName("duracion");

            builder.Property(x => x.Estado)
               .HasColumnName("estado");

            builder.Property(x => x.Total)
                .HasColumnName("total");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }  

}

using GestionServicios.Domain.Contrataciones;
using GestionServicios.Domain.Transactions;
using GestionServicios.Domain.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<IServicioFactory, ServicioFactory>();
            services.AddSingleton<ITransactionFactory, TransactionFactory>();
            services.AddSingleton<IContratacionFactory, ContratacionFactory>();



            return services;
        }

    }
}

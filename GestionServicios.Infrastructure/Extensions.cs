using GestionServicios.Application;
using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Contrataciones;
using GestionServicios.Domain.Servicios;
using GestionServicios.Domain.Transactions;
using GestionServicios.Domain.Users;
using GestionServicios.Infrastructure.DomainModel;
using GestionServicios.Infrastructure.Repositories;
using GestionServicios.Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<StoredDbContext>(context => 
                context.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));
        services.AddDbContext<DomainDbContext>(context =>
                context.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IServicioRepository, ServicioRepository>();
        services.AddScoped<IContratacionRepository, ContratacionRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAplication();

        return services;
    }
}

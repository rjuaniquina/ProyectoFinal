
using GestionServicios.Domain.Servicios;
using GestionServicios.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.Repositories
{
    internal class ServicioRepository : IServicioRepository
    {
        private readonly DomainDbContext _dbContext;

        public ServicioRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Servicio entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Remove(obj);
        }

        public async Task<Servicio?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Servicio.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            }
            else
            {
                return await _dbContext.Servicio.FindAsync(id);
            }
        }

        public Task UpdateAsync(Servicio servicio)
        {
            _dbContext.Servicio.Update(servicio);

            return Task.CompletedTask;
        }
    }
}

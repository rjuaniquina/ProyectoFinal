using GestionServicios.Domain.Contrataciones;
using GestionServicios.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Infrastructure.Repositories
{
    internal class ContratacionRepository:IContratacionRepository
    {
        private readonly DomainDbContext _dbContext;

        public ContratacionRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Contratacion entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
           var obj = await GetByIdAsync(id);
           _dbContext.Remove(obj);
        }

        public async Task<Contratacion?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Contratacion.AsNoTracking().FirstOrDefaultAsync(c => c.Id==id);
            }
            else
            {
                return await _dbContext.Contratacion.FindAsync(id);
            }
        }

        public Task UpdateAsync(Contratacion contratacion)
        {
            _dbContext.Contratacion.Update(contratacion);

            return Task.CompletedTask;
        }
    }
}

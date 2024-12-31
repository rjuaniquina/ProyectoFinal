using GestionServicios.Domain.Transactions;
using GestionServicios.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionServicios.Infrastructure.Repositories
{
    internal class TransactionRepository:ITransactionRepository
    {
        private readonly DomainDbContext _dbContext;
        public TransactionRepository(DomainDbContext domainDbContext)
        {
            _dbContext = domainDbContext;
        }
        public async Task AddAsync(Transaction obj)
        {
            await _dbContext.Transaction.AddAsync(obj);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            if (obj != null)
                _dbContext.Transaction.Remove(obj);
        }

        public async Task<Transaction?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Transaction.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            }
            else
            {
                return await _dbContext.Transaction.Include("_contrataciones").SingleOrDefaultAsync(c => c.Id == id);
            }
        }

        public Task UpdateAsync(Transaction transaction)
        {
            _dbContext.Transaction.Update(transaction);
            return Task.CompletedTask;
        }
    }
}

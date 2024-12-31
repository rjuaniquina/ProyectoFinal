using GestionServicios.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Transactions;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(Guid id);
}

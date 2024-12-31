using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Transactions.CreateTransaction
{
    public record CreateTransactionCommand(Guid UserCreatorId, string Type, ICollection<CreateTransacionContratacionCommand> Contrataciones) : IRequest<Guid>;

    public record CreateTransacionContratacionCommand(Guid ContratacionId,Guid PacienteId , Guid ServicioId, decimal Total);
}

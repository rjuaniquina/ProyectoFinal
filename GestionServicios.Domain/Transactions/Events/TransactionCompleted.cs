using GestionServicios.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Transactions.Events;

public record TransactionCompleted : DomainEvent
{
    public Guid TransactionId { get; init; }
    public TransactionType TransactionType { get; init; }

    public ICollection<TransactionCompletedDetail> Details { get; init; }

    public TransactionCompleted(Guid transactionId, 
        TransactionType type, 
        ICollection<TransactionCompletedDetail> details)
    {
        TransactionId = transactionId;
        TransactionType = type;
        Details = details;
    }

    public record TransactionCompletedDetail(Guid ContratacionId, Guid PacienteId, Guid ServicioId, decimal total);
}

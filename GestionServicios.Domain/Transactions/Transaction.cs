using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Shared;
using GestionServicios.Domain.Transactions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Transactions;

public class Transaction : AggregateRoot
{
    public Guid CreatorId { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? CompletedDate { get; private set; }
    public DateTime? CancelDate { get; private set; }
    public CostValue Total { get; private set; }

    private List<TransactionContratacion> _contrataciones;
    public TransactionStatus Status { get; private set; }
    public TransactionType Type { get; set; }
    public ICollection<TransactionContratacion> Contrataciones { 
        get {
            return _contrataciones;
        } 
    }

    public Transaction(Guid creatorId, TransactionType type) : base(Guid.NewGuid())
    {
        CreatorId = creatorId;
        Status = TransactionStatus.Created;
        CreationDate = DateTime.Now;
        Total = 0;
        _contrataciones = new List<TransactionContratacion>();
        Type = type;
    }

    public void AddItem(Guid contratacionId, Guid pacienteId, Guid servicioId, decimal total)
    {
        if(Status != TransactionStatus.Created)
        {
            throw new InvalidOperationException("Cannot add items to a transaction that is not in Created status");
        }
        TransactionContratacion contratacion = new TransactionContratacion(contratacionId, pacienteId, servicioId,total);
        _contrataciones.Add(contratacion);
        //TotalCost += item.SubTotal;
    }

    public void Complete()
    {
        if (Status != TransactionStatus.Created)
        {
            throw new InvalidOperationException("Cannot complete a transaction that is not in Created status");
        }
        if(_contrataciones.Count == 0)
        {
            throw new InvalidOperationException("Cannot complete a transaction with no items");
        }
        Status = TransactionStatus.Completed;
        CompletedDate = DateTime.Now;

        List<TransactionCompleted.TransactionCompletedDetail> detail = _contrataciones
            .Select(c => new TransactionCompleted.TransactionCompletedDetail(c.ContratacionId,c.PacienteId, c.ServicioId ,c.Total))
            .ToList();

        AddDomainEvent(new TransactionCompleted(Id, Type, detail));
    }

    public void Cancel()
    {
        if (Status != TransactionStatus.Created)
        {
            throw new InvalidOperationException("Cannot cancel a transaction that is not in Created status");
        }
        Status = TransactionStatus.Canceled;
        CancelDate = DateTime.Now;
    }

    public void UpdateContratacion(Guid contratacionId, decimal total)
    {
        if (Status != TransactionStatus.Created)
        {
            throw new InvalidOperationException("Cannot update items in a transaction that is not in Created status");
        }
        TransactionContratacion contratacion = _contrataciones.FirstOrDefault(c => c.ContratacionId == contratacionId);
        if (contratacion == null)
        {
            throw new InvalidOperationException("Contratacion not found in transaction");
        }
        //TotalCost -= contratacion.SubTotal;
        //contratacion.Update(quantity, unitaryCost);
        //TotalCost += contratacion.SubTotal;
    }

    public void RemoveItem(Guid contratacionId)
    {
        if (Status != TransactionStatus.Created)
        {
            throw new InvalidOperationException("Cannot remove items from a transaction that is not in Created status");
        }
        TransactionContratacion contratacion = _contrataciones.FirstOrDefault(c => c.ContratacionId == contratacionId);
        if (contratacion == null)
        {
            throw new InvalidOperationException("Item not found in transaction");
        }
        Total -= contratacion.Total;
        _contrataciones.Remove(contratacion);
    }

    //Need for EF Core
    private Transaction(){ }
}

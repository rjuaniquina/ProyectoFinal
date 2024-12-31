using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Domain.Transactions;

public class TransactionContratacion : Entity
{
    public Guid  ContratacionId { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid ServicioId { get; private set; }
    public CostValue Total { get; private set; }

    //public TransactionQuantity Quantity { get; private set; }

    public TransactionContratacion(Guid contratacinId, Guid pacienteId,Guid serviciosId,decimal total) : base(Guid.NewGuid())
    {
        ContratacionId = contratacinId;
        PacienteId = pacienteId;
        ServicioId = serviciosId;
        Total = total;
    }
 
    //internal void Update(int quantity, decimal unitaryCost)
    //{
    //    Quantity = quantity;
    //    UnitaryCost = unitaryCost;
    //    SubTotal = Quantity * UnitaryCost;
    //}

    //Need for EF Core
    private TransactionContratacion() { }
}

using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Contrataciones;
using GestionServicios.Domain.Transactions.Exceptions;
using GestionServicios.Domain.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Transactions.CreateTransaction;

internal class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, Guid>
{
    private readonly ITransactionFactory _transactionFactory;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IContratacionRepository _contratacionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransactionHandler(ITransactionFactory transactionFactory,
        ITransactionRepository transactionRepository,
        IUnitOfWork unitOfWork,
        IContratacionRepository contratacionRepository)
    {
        _transactionFactory = transactionFactory;
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
        _contratacionRepository = contratacionRepository;
    }

    public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {

        var transaction = request.Type switch
        {
            "Entry" => _transactionFactory.CreateEntryTransaction(request.UserCreatorId),
            "Exit" => _transactionFactory.CreateExitTransaction(request.UserCreatorId),
            _ => throw new TransactionCreationException("Invalid transaction type")
        };

        foreach (var contratacion in request.Contrataciones)
        {
            var storeContratacion= await _contratacionRepository.GetByIdAsync(contratacion.ContratacionId, true);
            if (storeContratacion == null)
            {
                throw new TransactionCreationException("Contratacion not found");
            }

            transaction.AddItem(contratacion.ContratacionId, contratacion.PacienteId,contratacion.ServicioId,contratacion.Total);
        }

        await _transactionRepository.AddAsync(transaction);

        await _unitOfWork.CommitAsync(cancellationToken);

        return transaction.Id;
    }
}
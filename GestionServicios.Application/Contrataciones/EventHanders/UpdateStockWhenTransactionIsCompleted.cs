using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Contrataciones;
using GestionServicios.Domain.Transactions;
using GestionServicios.Domain.Transactions.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Contratacion.EventHanders
{
    internal class UpdateStockWhenTransactionIsCompleted : INotificationHandler<TransactionCompleted>
    {
        private readonly IContratacionRepository _contratacionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStockWhenTransactionIsCompleted(IContratacionRepository contratacionRepository, IUnitOfWork unitOfWork)
        {
            _contratacionRepository = contratacionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TransactionCompleted domainEvent, CancellationToken cancellationToken)
        {
            foreach (var contratacion in domainEvent.Details)
            {
                var contratacionEntity = await _contratacionRepository.GetByIdAsync(contratacion.ContratacionId);
                if(contratacionEntity == null)
                {
                    continue;
                }
                var factor = domainEvent.TransactionType == TransactionType.Entry ? 1 : -1;

                //contratacionEntity.UpdateStockAndCost(factor * item.Quantity, item.unitaryCost);
                await _contratacionRepository.UpdateAsync(contratacionEntity);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

        }
    }
}

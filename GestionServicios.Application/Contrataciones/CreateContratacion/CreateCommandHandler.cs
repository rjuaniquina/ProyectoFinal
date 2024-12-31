using GestionServicios.Domain.Abstractions;
using GestionServicios.Domain.Contrataciones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionServicios.Application.Contratacion.CreateContratacion
{
    public class CreateCommandHandler : IRequestHandler<CreateContratacionCommand, Guid>
    {
        private readonly IContratacionFactory _contratacionFactory;
        private readonly IContratacionRepository _contratacionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCommandHandler(IContratacionFactory contratacionFactory,
                IContratacionRepository contratacionRepository,
                IUnitOfWork unitOfWork)
        {
            _contratacionFactory = contratacionFactory;
            _contratacionRepository = contratacionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateContratacionCommand request, CancellationToken cancellationToken)
        {           
            var contratacion =  _contratacionFactory.Create(request.id,request.paciente_id,request.servicio_id,request.fecha_contratacion,request.duracion,request.estado,request.total);           

            await _contratacionRepository.AddAsync(contratacion);

            await _unitOfWork.CommitAsync(cancellationToken);

            return contratacion.Id;
        }
    }
}

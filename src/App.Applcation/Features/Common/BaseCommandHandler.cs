using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Common;
using App.Domain.Common.Interfaces;
using App.Domain.Entities;
using AutoMapper;
using MediatR;
using ProductTable = App.Domain.Entities.Product;

namespace App.Applcation.Features
{
    public class BaseCommandHandler<TDomain> where TDomain : BaseAuditableEntity
    {
        protected readonly IMediator _mediator;
        protected readonly IGenericRepository<TDomain> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IDomainEventDispatcher _dispatcher;

        public BaseCommandHandler(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<TDomain> repository, IDomainEventDispatcher dispatcher)
        {
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _dispatcher = dispatcher;
        }
    }
}

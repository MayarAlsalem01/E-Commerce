using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Common;
using AutoMapper;
using MediatR;

namespace App.Applcation.Features.Common
{
    public class BaseQueryHandler<TDomain> where TDomain : BaseAuditableEntity
    {
        
        protected readonly IGenericRepository<TDomain> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseQueryHandler( IGenericRepository<TDomain> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        
        
    }
}

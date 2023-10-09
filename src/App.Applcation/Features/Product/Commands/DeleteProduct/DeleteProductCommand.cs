using App.Applcation.Common.Exceptions.DomainException;
using App.Applcation.Common.Exceptions.LogicException;
using App.Applcation.Dtos.Product;
using App.Applcation.Interfaces.IRepositories.Common;
using App.Domain.Common.Interfaces;
using AutoMapper;
using MediatR;
using ProductTable = App.Domain.Entities.Product;

namespace App.Applcation.Features.Product.Commands.DeleteProduct
{
    public sealed record  DeleteProductCommand:IRequest<ProductResponseDto>
    {
        public Guid id { get; set; }
      
    }
    public  class DeleteProductCommandHandler : BaseCommandHandler<ProductTable>, IRequestHandler<DeleteProductCommand, ProductResponseDto>
    {
        public DeleteProductCommandHandler(
            IMediator mediator,
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IGenericRepository<ProductTable> repository,
            IDomainEventDispatcher dispatcher) :
            base(mediator, mapper, unitOfWork, repository, dispatcher)
        {}

        public async Task<ProductResponseDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           
            var product= await _unitOfWork.Repository<ProductTable>().GetByIdAsync(request.id);
            if (product is null) throw new NotFoundException($"the product with id {request.id} not found");
            await _unitOfWork.Repository<ProductTable>().DeleteAsync(product);
            await _unitOfWork.Save(cancellationToken);
            
            return _mapper.Map<ProductResponseDto>(product); ;
        }
    }
}

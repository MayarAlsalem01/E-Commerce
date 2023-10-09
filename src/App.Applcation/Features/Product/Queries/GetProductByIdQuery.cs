using App.Applcation.Common.Exceptions.LogicException;
using App.Applcation.Dtos.Product;
using App.Applcation.Features.Common;
using App.Applcation.Interfaces.IRepositories.Common;
using AutoMapper;
using MediatR;
using ProductTable = App.Domain.Entities.Product;

namespace App.Applcation.Features.Product.Queries
{
    public class GetProductByIdQuery:IRequest<ProductResponseDto>
    {
        public Guid Id { get;private set; }
        public GetProductByIdQuery(Guid Id)
        {
            this .Id = Id;  
        }

    }
    internal class GetProductByIdHandler : BaseQueryHandler<ProductTable>,IRequestHandler<GetProductByIdQuery,ProductResponseDto>
    {
        public GetProductByIdHandler(
            IGenericRepository<ProductTable> repository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
        {
        }

        public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product=await _unitOfWork.Repository<ProductTable>().GetByIdAsync(request.Id);
            if (product == null) throw new NotFoundException();
            return _mapper.Map<ProductResponseDto>(product);
        }
    }
}

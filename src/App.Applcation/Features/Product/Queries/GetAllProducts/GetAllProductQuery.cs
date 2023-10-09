using App.Applcation.Dtos.Product;
using App.Applcation.Features.Common;
using App.Applcation.Interfaces.IRepositories.Common;
using AutoMapper;
using MediatR;
using ProductTable = App.Domain.Entities.Product;
namespace App.Applcation.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductQuery:IRequest<List<ProductResponseDto>>
    {

    }
    internal class GetAllProductQueryHandler :BaseQueryHandler<ProductTable>, IRequestHandler<GetAllProductQuery, List<ProductResponseDto>>
    {
        public GetAllProductQueryHandler(
            
            IGenericRepository<ProductTable> repository,
            IMapper mapper,
            IUnitOfWork unitOfWork) : base( repository, mapper, unitOfWork)
        {
        }

        public async Task<List<ProductResponseDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products =await _unitOfWork.Repository<ProductTable>().GetAllAsync(cancellationToken);           
            return _mapper.Map<List<ProductResponseDto>>(products);
        }
    }
}

using App.Applcation.Dtos.Pagination;
using App.Applcation.Dtos.Product;
using App.Applcation.Features.Common;
using App.Applcation.Interfaces.IRepositories.Common;
using App.Applcation.Interfaces.IServices;
using AutoMapper;
using MediatR;
using ProductTable=App.Domain.Entities.Product;

namespace App.Applcation.Features.Product.Queries.GetPaginatedProduct
{
    public class GetPaginatedProductQuery:IRequest<PaginationResponseDto<ProductResponseDto>>
    {
        public PaginationRequestDto PaginationRequestDto { get; set; }
    }
      class GetPaginatedProductQueryHandler :BaseQueryHandler<ProductTable> ,IRequestHandler<GetPaginatedProductQuery,PaginationResponseDto<ProductResponseDto>>
    {
        private readonly IPaginationService<ProductTable,ProductResponseDto> _pagerService;
        public GetPaginatedProductQueryHandler(
            IGenericRepository<ProductTable> repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IPaginationService<ProductTable, ProductResponseDto> pagerService) 
            : base(repository, mapper, unitOfWork)
        {
            _pagerService = pagerService;
        }

        public async Task<PaginationResponseDto<ProductResponseDto>> Handle(GetPaginatedProductQuery request, CancellationToken cancellationToken)
        {
            var result=await _pagerService.GetPaginatedDataAsync(request.PaginationRequestDto,cancellationToken);
            return result;
        }
    }
}

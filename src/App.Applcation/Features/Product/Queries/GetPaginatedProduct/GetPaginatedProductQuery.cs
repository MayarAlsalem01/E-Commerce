using App.Applcation.Common.Exceptions.LogicException;
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
        public GetPaginatedProductQuery(PaginationRequestDto dto)
        {
            PaginationRequestDto = dto;
        }
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
            var validtions = new GetPaginatedProductQueryValidtor();
            var resultValidantion =validtions.Validate(request.PaginationRequestDto);
            if (!resultValidantion.IsValid) throw new ValidationException("Bad Request",resultValidantion);
            var result=await _pagerService.GetPaginatedDataAsync(request.PaginationRequestDto,cancellationToken);
            return result;
        }
    }
}

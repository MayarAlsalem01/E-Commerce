using App.Applcation.Dtos.Pagination;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Features.Product.Queries.GetPaginatedProduct
{
    internal class GetPaginatedProductQueryValidtor:AbstractValidator<PaginationRequestDto>
    {
        public GetPaginatedProductQueryValidtor()
        {
            RuleFor(p => p.PageSize)
                .GreaterThan(0)
                .WithMessage("pageSize should be more than 0 ");
            RuleFor(p => p.PageNumber)
              .GreaterThan(0)
              .WithMessage("pageNumber should be more than 0 ");
        }
    }
}

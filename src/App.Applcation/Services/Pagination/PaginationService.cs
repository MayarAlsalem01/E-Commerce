using App.Applcation.Dtos.Pagination;
using App.Applcation.Interfaces.IRepositories.Common;
using App.Applcation.Interfaces.IServices;
using App.Domain.Common.Interfaces;
using App.Domain.Specifications.Pagination;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Services.Pagination
{
    public  class PaginationService<TEntity,TDto>: IPaginationService<TEntity, TDto> where TEntity : class, IEntity
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapperl;
        public PaginationService(IGenericRepository<TEntity> repository, IMapper mapperl)
        {
            _repository = repository;
            _mapperl = mapperl;
        }

        public async Task<PaginationResponseDto<TDto>> GetPaginatedDataAsync(PaginationRequestDto requestDto,CancellationToken cancellationToken)
        {
            var specification = new PaginationSpecification
            {
                PageNumber = requestDto.PageNumber,
                PageSize = requestDto.PageSize
            };

            var totalItems = await _repository.CountAsync(specification,cancellationToken);
            var data = await _repository.GetBySpecificationAsync(specification,cancellationToken);
            var dataDto = _mapperl.Map<List<TDto>>(data);
            return new PaginationResponseDto<TDto>
            {
                TotalItems = totalItems,
                CurrentPage = requestDto.PageNumber,
                PageSize = requestDto.PageSize,
                Data = dataDto
            };
        }
    }
}

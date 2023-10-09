using App.Applcation.Dtos.Pagination;


namespace App.Applcation.Interfaces.IServices
{
    public interface IPaginationService<TEntity ,TDto>
    {
        Task<PaginationResponseDto<TDto>> GetPaginatedDataAsync(PaginationRequestDto requestDto,CancellationToken cancellationToken);
    }
}

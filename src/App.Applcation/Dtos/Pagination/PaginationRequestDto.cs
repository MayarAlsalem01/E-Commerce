

namespace App.Applcation.Dtos.Pagination
{
    public sealed class PaginationRequestDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

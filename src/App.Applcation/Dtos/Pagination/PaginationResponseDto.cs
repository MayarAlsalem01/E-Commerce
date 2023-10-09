

namespace App.Applcation.Dtos.Pagination
{
    public sealed class PaginationResponseDto<T>
    {
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; set; } = new List<T>();
    }
}

namespace PROD_STOCK_API.DTOs
{
    public class PaginationResultDto<T>
    {
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
    }
}

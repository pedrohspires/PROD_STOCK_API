namespace PROD_STOCK_API.DTOs
{
    public class FilterPaginationDto
    {
        public string? Search { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
    }
}

namespace PROD_STOCK_API.DTOs.ProductCategory
{
    public class ProductCategoryDto : BaseDto
    {
        public string? Description { get; set; } = string.Empty;
        public bool? Active { get; set; }
    }
}

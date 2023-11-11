using System.ComponentModel.DataAnnotations.Schema;

namespace PROD_STOCK_API.Entities
{
    [Table("product")]
    public class Product: BaseEntity
    {
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("bar_code")]
        public string? BarCode { get; set; }

        [Column("id_product_category")]
        public int ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}

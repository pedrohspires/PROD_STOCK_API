using System.ComponentModel.DataAnnotations.Schema;

namespace PROD_STOCK_API.Entities
{
    [Table("product_category")]
    public class ProductCategory : BaseEntity
    {
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("active")]
        public bool Active { get; set; }
    }
}

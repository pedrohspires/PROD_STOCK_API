using System.ComponentModel.DataAnnotations.Schema;

namespace PROD_STOCK_API.Entities
{
    [Table("purchase")]
    public class Purchase : BaseEntity
    {
        [Column("value")]
        public decimal Value { get; set; }

        [Column("purchased_by")]
        public string PurchasedBy { get; set; } = string.Empty;

        [Column("id_product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

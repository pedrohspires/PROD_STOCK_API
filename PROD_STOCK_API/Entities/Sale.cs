using System.ComponentModel.DataAnnotations.Schema;

namespace PROD_STOCK_API.Entities
{
    [Table("sale")]
    public class Sale : BaseEntity
    {
        [Column("value")]
        public decimal Value { get; set; }

        [Column("sold_by")]
        public string SoldBy { get; set; } = string.Empty;

        [Column("id_product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}

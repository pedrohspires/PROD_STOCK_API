using System.ComponentModel.DataAnnotations.Schema;

namespace PROD_STOCK_API.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt  { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}

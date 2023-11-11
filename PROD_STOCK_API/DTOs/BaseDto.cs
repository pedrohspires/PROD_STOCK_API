using System.ComponentModel.DataAnnotations.Schema;

namespace PROD_STOCK_API.DTOs
{
    public class BaseDto
    {
        public int? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

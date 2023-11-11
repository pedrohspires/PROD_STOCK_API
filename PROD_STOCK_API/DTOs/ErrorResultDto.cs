namespace PROD_STOCK_API.DTOs
{
    public class ErrorResultDto
    {
        public bool IsValidation { get; set; }
        public object Error { get; set; }
    }
}

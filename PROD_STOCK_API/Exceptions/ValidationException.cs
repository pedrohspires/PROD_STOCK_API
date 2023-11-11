namespace PROD_STOCK_API.Exceptions
{
    public class ValidationException : Exception
    {
        public readonly List<string> Fields;

        public ValidationException(List<string> fields)
        {
            this.Fields = fields;
        }

        public ValidationException(string message, List<string> fields) : base(message)
        {
            this.Fields = fields;
        }

        public ValidationException(string message, Exception inner, List<string> fields) : base(message, inner)
        {
            this.Fields = fields;
        }
    }
}

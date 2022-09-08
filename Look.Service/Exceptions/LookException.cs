namespace Look.Service.Exceptions
{
    public class LookException : Exception
    {
        public int Code { get; set; }
        public LookException(int code, string message)
            : base(message)
        {
            this.Code = code;
        }
    }
}

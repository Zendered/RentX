namespace RentX.Exceptions
{
    public class ServiceResponseException<T>
    {
        public string Message { get; } = string.Empty;
        public T? Data { get; }
        public bool Success { get; }

        public ServiceResponseException(T? Data, string Message, bool Success = false)
        {
            this.Message = Message;
            this.Data = Data;
            this.Success = Success;
        }
    }
}

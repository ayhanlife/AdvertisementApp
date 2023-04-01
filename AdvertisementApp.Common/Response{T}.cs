namespace AdvertisementApp.Common
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
        public Response(ResponseType responseType, string message) : base(responseType, message)
        {

        }
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(T data, List<CustomValidationError> error) : base(ResponseType.ValidationError)
        {
            ValidationErrors = error;
            Data = data;
        }
    }
}

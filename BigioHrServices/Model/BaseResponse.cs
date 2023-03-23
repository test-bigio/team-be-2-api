namespace BigioHrServices.Model
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(object data, string message)
        {
            this.Data = data;
            this.Message = message;
        }

        public object Data { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

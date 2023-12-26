using GoFive_CRM.Application.Models;
using Newtonsoft.Json;
namespace GoFive_CRM.ViewModels
{
    public class BaseResponse
    {
        [JsonProperty("is_success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("response_message")]
        public string ResponseMessage { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
    public class ErrorResponse : BaseResponse
    {

    }
    public class ErrorResponse<T> : BaseResponse
    {
        [JsonProperty("error")]
        public T Error { get; set; }
    }

    public class CreateCustomerResponse : BaseResponse<CustomerModel>
    {

    }
}

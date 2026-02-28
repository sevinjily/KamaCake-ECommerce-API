using System.Net;

namespace KamaCake.Application.Wrappers.ServiceResponses
{
    public class ServiceResponse
    {
        public bool isSuccess { get;  set; }    // əməliyyat uğurlu olub-olmadığını göstərir
        public string Message { get;  set; }
        public HttpStatusCode StatusCode { get;  set; }

        //MESAJSIZ
        public ServiceResponse(bool IsSuccess, HttpStatusCode statusCode)
        {
            isSuccess = IsSuccess;
            StatusCode = statusCode;
        }
        //MESAJLI
        public ServiceResponse(bool IsSuccess, HttpStatusCode statusCode, string message) : this(IsSuccess, statusCode)
        {
            {

                Message = message;
            }

        }
        public ServiceResponse()
        {
            
        }
    }
}

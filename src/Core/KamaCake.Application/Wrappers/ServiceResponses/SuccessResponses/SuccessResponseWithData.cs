using System.Net;

namespace KamaCake.Application.Wrappers.ServiceResponses.SuccessResponses
{
    public class SuccessResponseWithData<T> : ServiceResponseWithData<T>
    {
        //mesajsiz
        public SuccessResponseWithData(T value, bool isSuccess, HttpStatusCode statusCode) : base(value, true, statusCode)
        {
        }

        //mesajli
        public SuccessResponseWithData(T value, bool isSuccess, HttpStatusCode statusCode,string message) : base(value, true, statusCode,message)
        {
        }
    }
}

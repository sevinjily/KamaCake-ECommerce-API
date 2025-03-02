using Business.Message.Abstract;
using System.Net;

namespace Business.Message.Concrete
{
    public class Result : IResult
    {
        public bool Success { get; }  //readonly property

        public string Message { get; }

        public HttpStatusCode StatusCode { get; }

        public Result(string message,bool success,HttpStatusCode statusCode): this(success,statusCode)
        {
            Message = message;
        }
        public Result(bool success,HttpStatusCode statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }


    }
}

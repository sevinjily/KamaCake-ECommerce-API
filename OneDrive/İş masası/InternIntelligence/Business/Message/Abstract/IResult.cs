using System.Net;

namespace Business.Message.Abstract
{
   public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }
    }
}

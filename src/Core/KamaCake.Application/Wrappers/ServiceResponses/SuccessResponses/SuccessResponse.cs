using System.Net;

namespace KamaCake.Application.Wrappers.ServiceResponses.SuccessResponses
{
    public class SuccessResponse:ServiceResponse

    {
        //mesajsiz
        public SuccessResponse(bool isSuccess, HttpStatusCode statusCode) : base(true, statusCode)
        {

        }
        //mesajli
        public SuccessResponse(bool isSuccess,HttpStatusCode statusCode,string message):base(true,statusCode,message)
        {
            
        }
    }
}

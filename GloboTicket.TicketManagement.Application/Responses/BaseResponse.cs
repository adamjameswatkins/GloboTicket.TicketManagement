using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            this.Success = true;
        }

        public BaseResponse(string message = null)
        {
            this.Success = true;
            this.Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; internal set; }
        public string Message { get; }
        public List<string> ValidationErrors { get; internal set; }
    }
}

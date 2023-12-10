namespace API.Errors
{
    
    public class ApiResponse
    {
        public ApiResponse(int statusCodes, string message=null)
        {
            StatusCodes = statusCodes;
            Message = message ??GetDefaultMessageForStatusCode(StatusCodes);
        }

        
        public int StatusCodes { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCodes)
        {
            return statusCodes switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized,you are not",
                404 => "Resource found, it was not",
                500 =>"Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career changes",
                _=>null
            };
        }

    }
}

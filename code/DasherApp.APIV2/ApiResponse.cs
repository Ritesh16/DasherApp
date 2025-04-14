using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DasherApp.APIV2
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string Message { get; set; }
        public ApiResponse(T data, int statusCode = 200,  string message = "Success")
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
            Success = true;
        }
        public ApiResponse(int statusCode, string errorMessage = null, List<string> errors = null)
        {
            Success = false;
            StatusCode = statusCode;
            Message = errorMessage ?? "An error occurred";
            Errors = errors ?? new List<string>();
        }
    }
}

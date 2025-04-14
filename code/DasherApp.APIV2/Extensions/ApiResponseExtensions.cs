namespace DasherApp.APIV2.Extensions
{
    public static class ApiResponseExtensions
    {
        public static ApiResponse<T> Success<T>(this T data, string message = "Success", int statusCode = 200)
        {
            return new ApiResponse<T>(data, statusCode, message);
        }

        public static ApiResponse<T> Failure<T>(this string errorMessage, int statusCode = 400, List<string> errors = null)
        {
            return new ApiResponse<T>(statusCode, errorMessage, errors);
        }


    }
}

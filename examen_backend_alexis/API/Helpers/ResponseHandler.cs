using examen_backend_alexis.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace examen_backend_alexis.API.Helpers
{
    public static class ResponseHandler
    {

        public static IActionResult Success<T>(T data, string message = "Success", int status = 200)
        {
            var response = new ApiResponse<T>(data, message, status);
            return new ObjectResult(response) { StatusCode = status };
        }

        public static IActionResult Error(string message, int status = 400)
        {
            var response = new ApiResponse<object>(null, message, status);
            return new ObjectResult(response) { StatusCode = status };
        }
    }
}

using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public class ErrorHandlerMiddleware
  {
    private readonly ILoggerFactory _loggerFactory; 
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
    {
      _loggerFactory = loggerFactory;
      _next = next;
    }

    public async Task Invoke(HttpContext context){
      var _logger = _loggerFactory.CreateLogger<ErrorHandlerMiddleware>();

      try
      {
          await _next(context);
      }
      catch (Exception error)
      {
        var response = context.Response;
        response.ContentType = "application/json";
        var responseModel = new Response<string>(){Succeeded = false, Message = error?.Message};
        switch (error)
        {
          case Application.Exceptions.ApiException e:
            // custom application error
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            break;
          case Application.Exceptions.ValidationException e:
            // custom application error
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            responseModel.Errors = e.Errors;
            break;
          case KeyNotFoundException e:
            // not found error
            response.StatusCode = (int)HttpStatusCode.NotFound;
            break;
          default:
            // unhandled error
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            break;
        }
        var result = JsonSerializer.Serialize(responseModel);
         _logger.LogError($"An error has occurred {DateTime.UtcNow}(UTC) :::: {error.Message} \n {error}");
        await response.WriteAsync(result);
      }
    }
  }
}

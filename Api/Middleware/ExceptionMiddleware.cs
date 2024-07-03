using Api.Communication;
using Api.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Api.Middleware
{
	public class ExceptionMiddleware(RequestDelegate next)
	{
		private readonly RequestDelegate _next = next;

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch
			{
				await HandleExceptionAsync(httpContext);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var response = new ResponseWrapper<EmptyResponse>(OperationStatus.Failed, "Internal server error");

			var jsonResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings
			{
				Converters = [new StringEnumConverter()]
			});
			return context.Response.WriteAsync(jsonResponse);
		}
	}
}

using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using VeterinaryClinic.BLL.Exceptions;

namespace VeterinaryClinicManagementSystem.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var (status, title, detail) = ex switch
            {
                NotFoundException => (HttpStatusCode.NotFound, "Not Found", ex.Message),
                ConflictException => (HttpStatusCode.Conflict, "Conflict", ex.Message),
                UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized", "Access is denied."),
                ValidationException => (HttpStatusCode.BadRequest, "Validation Error", ex.Message),
                ArgumentException => (HttpStatusCode.BadRequest, "Bad Request", ex.Message),
                _ => (HttpStatusCode.InternalServerError, "Internal Server Error", "An unexpected error occurred.")
            };

            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/json";

            var problem = new ProblemDetails
            {
                Status = (int)status,
                Title = title,
                Detail = detail,
                Instance = context.Request.Path
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            await context.Response.WriteAsJsonAsync(problem, options);
        }
    }
}

namespace HarshaApi1.Middleware
{
    public class ExceptionMiddleware(RequestDelegate requestDelegate)
    {
        public  readonly RequestDelegate Next =requestDelegate;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
               await Next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await  httpContext.Response.WriteAsJsonAsync($"Error: {ex.Message}");
                throw;
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace HarshaApi1.Filters
{
    public class MethodExpiredFilter2:IAsyncActionFilter
    {
        public ILogger<MethodExpiredFilter2> Logger { get; set; }
        public MethodExpiredFilter2(ILogger<MethodExpiredFilter2> logger)
        {
            Logger = logger;
        }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Before action is e executing");
            // context.Result = new OkObjectResult("method is expired");
            next();
            Console.WriteLine($"after action is e executed order");
            return Task.CompletedTask;
        }
    }
}

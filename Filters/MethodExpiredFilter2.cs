using Microsoft.AspNetCore.Mvc.Filters;

namespace HarshaApi1.Filters
{
    public class MethodExpiredFilter2 : IAsyncActionFilter
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
#warning using the ActionFilterAttribute we are not using the Construcotr Injection.
    public class MethodExpiredFilter3 : ActionFilterAttribute
    {
        public MethodExpiredFilter3(int order)
        {
            Order = order;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Before action is e executing Order is {Order}");
            // context.Result = new OkObjectResult("method is expired");
            await next();
            Console.WriteLine($"after action is e executed order is {Order}");
        }
    }
}

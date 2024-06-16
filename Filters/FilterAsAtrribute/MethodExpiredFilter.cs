using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HarshaApi1.Filters.FilterAsAtrribute
{
    public class MethodExpiredFilter : Attribute,IFilterFactory
    {
        public int Order { get; set; }
        public ILogger<MethodExpiredFilter> Logger { get; set; }

        public bool IsReusable => false ;

        public MethodExpiredFilter(int order,ILogger<MethodExpiredFilter> logger)
        {
            Order = order;
            Logger = logger;
        }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Before action is e executing order is {Order}");
           // context.Result = new OkObjectResult("method is expired");
            next();
            Console.WriteLine($"after action is e executed order is {Order}");
            return Task.CompletedTask;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace HarshaApi1.Filters
{
    public class StudentActionFilter : IActionFilter,IOrderedFilter
    {
        public int Order { get; }
        public ILogger<StudentActionFilter>? Logger { get; set; }
        public StudentActionFilter(ILogger<StudentActionFilter>? logger,int order)
        { Logger = logger;
          Order = order;
        }
        public void OnActionExecuted(ActionExecutedContext contex)
        {
            Logger?.LogInformation($"After action is Method is called and Order is {Order}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger?.LogInformation($"Before action is Method is called Order is {Order}");
        }
    }
}

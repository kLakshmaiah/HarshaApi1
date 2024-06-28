using HarshaApi1.Filters;
using HarshaApi1.Filters.FilterAsAtrribute;
using HarshaApi1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HarshaApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        //[ServiceFilter(typeof(MethodExpiredFilter2))]
        //[Filters.FilterAsAtrribute.MethodExpiredFilter(1)]
        [MethodExpiredFilter3(2)]
        public IActionResult GetEmployee(Employee employee)
        {
            return Ok("Employee");
        }
    }
}

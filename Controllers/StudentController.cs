using HarshaApi1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HarshaApi1.Data;
using HarshaApi1.Filters;
namespace HarshaApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [TypeFilter(typeof(StudentActionFilter),Arguments = new Object[] {3},Order =3)]
    //[TypeFilter(typeof(MethodExpiredFilter), Arguments = new Object[] { 2 },Order =2)]
    public class StudentController : ControllerBase
    {
        public StudentController(HasrhaApiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public HasrhaApiDbContext DbContext { get; }

       // [TypeFilter(typeof(StudentActionFilter))]
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody]Student student)
        {
          // await DbContext.StudentTbl.AddAsync(student);
          //await  DbContext?.SaveChangesAsync();
          int insertedrecords = await DbContext.Sp_InsertStudentAsync(student);

           return Ok(string.Join(" ",new object[] { insertedrecords, " record is inserted" }));
        }
        [HttpGet]
        [Produces("application/xml")]
        public async Task<IActionResult> GetStudents()
        {
            List<Student>? StudentList =await DbContext.Sp_GetAllStudentsAsync();
            return Ok(StudentList);
        }
        [HttpGet("studentId")]
        public IActionResult GetStudent(int studentId)
        {
            Student? student1 = DbContext?.StudentTbl?.Where(s => s.Id == studentId).FirstOrDefault();
            return Ok(student1);
        }
       // [TypeFilter(typeof(MethodExpiredFilter), Arguments = new Object[] { 1 },Order =1)]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            int deleterecords = await DbContext.Sp_DeleteStudentAsync(studentId);
            return Ok(string.Join(" ", new object[] { deleterecords, " record is deleted" }));
        }
        [NonAction]
        private IActionResult MyCustomMethod()
        {
            return Ok("This is my custom method");
        }
    }
}

using HarshaApi1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HarshaApi1.Data
{
    public class HasrhaApiDbContext : IdentityDbContext<ApplicationUser, ApplicationRoles, Guid>
    {
        public HasrhaApiDbContext(DbContextOptions<HasrhaApiDbContext> contextOptions) : base(contextOptions)
        {
        }
        public DbSet<Student>? StudentTbl { get; set; }
        public DbSet<Employee>? EmployeesTbl { get; set; }

        //calling the StoredProcedure

        public async Task<List<Student>?> Sp_GetAllStudentsAsync()
        {
            return StudentTbl?.FromSqlRaw("EXECUTE [dbo].[GetStudents_SP]").ToList();
        }
        public async Task<int> Sp_DeleteStudentAsync(int StudentId)
        {
            SqlParameter sqlParameter = new SqlParameter($"@{nameof(StudentId)}", StudentId);
            return Database.ExecuteSqlRaw($"EXECUTE [dbo].[DeleteStudent_Sp] @{nameof(StudentId)}", sqlParameter);
        }
        public async Task<int> Sp_InsertStudentAsync(Student student)
        {
            SqlParameter[] sqlParameters = {
                new SqlParameter($"@{nameof(student.Name)}", student.Name),
                new SqlParameter($"@{nameof(student.RollNo)}", student.RollNo),
                new SqlParameter($"@{nameof(student.Class)}", student.Class),
                new SqlParameter($"@{nameof(student.Section)}", student.Section),
                new SqlParameter($"@{nameof(student.MobileNumber)}", student.MobileNumber)
            };
            return Database.ExecuteSqlRaw($"EXECUTE [dbo].[InsertStudent_Sp] @{nameof(student.Name)},@{nameof(student.RollNo)},@{nameof(student.Class)},@{nameof(student.Section)},@{nameof(student.MobileNumber)}", sqlParameters);
        }
    }
}

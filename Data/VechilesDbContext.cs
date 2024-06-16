using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HarshaApi1.Data
{
    public class VechilesDbContext:DbContext
    {
        public VechilesDbContext(DbContextOptions<VechilesDbContext> dbContextOptions):base() {
        
        }
    }
}

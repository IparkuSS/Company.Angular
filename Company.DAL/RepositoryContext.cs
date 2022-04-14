using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Models.Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

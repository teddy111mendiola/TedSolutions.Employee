using Microsoft.EntityFrameworkCore;
using System.Data;
using TedSolutions.Employee.Models.Entities;
namespace TedSolutions.Employee.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet <Employee.Models.Entities.Employee> Employees { get; set; }
    }
}

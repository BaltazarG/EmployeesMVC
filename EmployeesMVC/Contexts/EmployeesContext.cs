using EmployeesMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC.Contexts
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}

using EmployeesMVC.Contexts;
using EmployeesMVC.Models;
using EmployeesMVC.Models.Domain;
using EmployeesMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC.Repositories.Implementations
{
    
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesContext _context;

        public EmployeeRepository(EmployeesContext context)
        {
            _context = context;
        }

        public async Task AddEmployee(AddEmployeeViewModel newEmployee)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = newEmployee.Name,
                Email = newEmployee.Email,
                Salary = newEmployee.Salary,
                DateOfBith = newEmployee.DateOfBith,
                Department = newEmployee.Department
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

           
            return employee;
            
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task RemoveEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeViewModel updatedEmployee)
        {
            var employee = await GetEmployee(updatedEmployee.Id);

            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Salary = updatedEmployee.Salary;
                employee.DateOfBith = updatedEmployee.DateOfBith;
                employee.Department = updatedEmployee.Department;

                await _context.SaveChangesAsync();
            }
        }

    }
}

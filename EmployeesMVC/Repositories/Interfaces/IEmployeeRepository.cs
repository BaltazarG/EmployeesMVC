using EmployeesMVC.Models;
using EmployeesMVC.Models.Domain;

namespace EmployeesMVC.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(Guid id);
        public Task RemoveEmployee(Guid id);
        public Task AddEmployee(AddEmployeeViewModel newEmployee);
        public Task UpdateEmployee(UpdateEmployeeViewModel updatedEmployee);
    }
}

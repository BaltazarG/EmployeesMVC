using EmployeesMVC.Contexts;
using EmployeesMVC.Models;
using EmployeesMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesContext _context;
        public EmployeesController(EmployeesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBith = addEmployeeRequest.DateOfBith,
                Department = addEmployeeRequest.Department
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                            {
                                Id = id,
                                Name = employee.Name,
                                Email = employee.Email,
                                Salary = employee.Salary,
                                DateOfBith = employee.DateOfBith,
                                Department = employee.Department
                            };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeViewModel model)
        {
            var employee = await _context.Employees.FindAsync(model.Id);

            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBith = model.DateOfBith;
                employee.Department = model.Department;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await _context.Employees.FindAsync(model.Id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}

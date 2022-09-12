using EmployeesMVC.Contexts;
using EmployeesMVC.Models;
using EmployeesMVC.Models.Domain;
using EmployeesMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetEmployees();
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
            await _employeeRepository.AddEmployee(addEmployeeRequest);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await _employeeRepository.GetEmployee(id);

            if (employee != null)
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
            await _employeeRepository.UpdateEmployee(model);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            await _employeeRepository.RemoveEmployee(model.Id);

            return RedirectToAction("Index");

        }
    }
}

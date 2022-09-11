﻿namespace EmployeesMVC.Models
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double Salary { get; set; }
        public DateTime DateOfBith { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}

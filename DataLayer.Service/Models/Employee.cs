using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace employ.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public virtual Department Department { get; set; } = null!;
}

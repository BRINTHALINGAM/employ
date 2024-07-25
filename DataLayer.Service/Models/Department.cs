using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace employ.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string? DepartmentDescription { get; set; }

    public DateOnly CreatedDate { get; set; }


    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

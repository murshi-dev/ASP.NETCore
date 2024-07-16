using System;
using System.Collections.Generic;

namespace DBFirstMay24.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public decimal Salary { get; set; }

    public DateOnly DateOfJoin { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}

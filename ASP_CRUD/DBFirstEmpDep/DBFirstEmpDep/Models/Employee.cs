using System;
using System.Collections.Generic;

namespace DBFirstEmpDep.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public DateTime DateOfJoin { get; set; }

    public decimal Salary { get; set; }

    public int? DepId { get; set; }

    public virtual Department? Dep { get; set; }
}

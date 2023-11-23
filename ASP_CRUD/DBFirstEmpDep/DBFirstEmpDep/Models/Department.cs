using System;
using System.Collections.Generic;

namespace DBFirstEmpDep.Models;

public partial class Department
{
    public int DepId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

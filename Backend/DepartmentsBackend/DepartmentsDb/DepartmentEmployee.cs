using System;
using System.Collections.Generic;

namespace DepartmentsDb;

public partial class DepartmentEmployee
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}

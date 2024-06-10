using System;
using System.Collections.Generic;

namespace DepartmentsDb;

public partial class EmployeeSkill
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int SkillId { get; set; }

    public DateTime DateSince { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}

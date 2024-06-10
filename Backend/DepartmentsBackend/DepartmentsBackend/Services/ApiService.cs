namespace DepartmentsBackend.Services;

public class ApiService(DepartmentsContext db) : IApiService {
    public List<SkillDto> GetSkills() {
        return db.Skills.ToList()
            .Select(skill => (skill, count: db.EmployeeSkills
                .Count(x => x.SkillId == skill.Id)))
            .Select(x => new SkillDto {
                Id = x.skill.Id,
                Name = x.skill.Name,
                NumberOfEmployees = x.count,
            })
            .ToList();
    }
    
    public List<DepartmentDto> GetDepartments() {
        return db.Departments.ToList()
            .Select(department => new {
                department,
                count = db.DepartmentEmployees.Where(x => x.DateTo == null)
                    .Count(x => x.DepartmentId == department.Id)
            })
            .Select(t => new DepartmentDto {
                Id = t.department.Id,
                Name = t.department.Name,
                NumberOfEmployees = t.count,
            }).ToList();
    }
    
    public DepartmentDto? GetDepartment(int id) {
        var department = db.Departments.First(x => x.Id == id);
        return new DepartmentDto().CopyFrom(department);
    }
    
    public List<DepartmentEmployeeDto> GetDepartmentEmployees(int id) {
        return db.DepartmentEmployees.Where(x => x.DepartmentId == id)
            .Select(x => new DepartmentEmployeeDto {
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                EmployeeId = x.EmployeeId,
                EmployeeName = x.Employee.Firstname + " " + x.Employee.Lastname,
                SkillNames = x.Employee.EmployeeSkills.Select(skill => skill.Skill.Name).ToList(),
            })
            .ToList();
    }
}
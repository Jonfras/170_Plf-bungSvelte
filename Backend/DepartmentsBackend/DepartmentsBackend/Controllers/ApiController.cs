namespace DepartmentsBackend.Controllers;
[ApiController]
public class ApiController(IApiService db) : ControllerBase {
    [HttpGet("skills")]
    public List<SkillDto> GetSkills() {
        return db.GetSkills()
            .Select(x => new SkillDto().CopyFrom(x))
            .ToList();
    }
    
    [HttpGet("departments")]
    public List<DepartmentDto> GetDepartments() {
        return db.GetDepartments()
            .Select(x => new DepartmentDto().CopyFrom(x))
            .ToList();
    }
    
    [HttpGet("departments/{id:int}")]
    public DepartmentDto? GetDepartment(int id) {
        return db.GetDepartment(id);
    }
    
    [HttpGet("departments/{id:int}/employees")]
    public List<DepartmentEmployeeDto> GetDepartmentEmployees(int id) {
        return db.GetDepartmentEmployees(id);
    }
}
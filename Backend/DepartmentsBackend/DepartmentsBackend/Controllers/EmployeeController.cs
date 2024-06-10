namespace DepartmentsBackend.Controllers;
[ApiController]
public class EmployeeController(IEmployeeService db) : ControllerBase {
    
    [HttpGet("employees")]
    public List<EmployeeDto> GetEmployees() {
        return db.GetEmployees()
            .Select(x => new EmployeeDto().CopyFrom(x))
            .ToList();
    }
    
    [HttpDelete("employees/{id:int}")]
    public EmployeeDto DeleteEmployee(int id) {
        return new EmployeeDto().CopyFrom(db.DeleteEmployee(id)
            .Entity);
    }
    
    [HttpGet("skills/{id}/employees")]
    public List<EmployeeDto> GetEmployeesForSkill(int id) {
        return db.GetEmployeesForSkill( id);
    }
    
    
}
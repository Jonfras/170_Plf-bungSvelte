using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DepartmentsBackend.Services;

public interface IEmployeeService {
    public IEnumerable<EmployeeDto> GetEmployees();
    EntityEntry<Employee> DeleteEmployee(int id);
    List<EmployeeDto> GetEmployeesForSkill(int id);
}
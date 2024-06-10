using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DepartmentsBackend.Services;

public class EmployeeService(DepartmentsContext db) : IEmployeeService {
    public IEnumerable<EmployeeDto> GetEmployees() {
        return db.DepartmentEmployees.Include(departmentEmployee => departmentEmployee.Department)
            .Include(departmentEmployee => departmentEmployee.Employee)
            .ToList()
            .Select(departmentEmployee => new EmployeeDto {
                City = departmentEmployee.Employee.City,
                DepartmentId = departmentEmployee.DepartmentId,
                DepartmentName = departmentEmployee.Department.Name,
                Firstname = departmentEmployee.Employee.Firstname,
                Lastname = departmentEmployee.Employee.Lastname,
                Id = departmentEmployee.EmployeeId,
            })
            .DistinctBy(x => x.Id)
            .ToList();
    }
    
    public EntityEntry<Employee> DeleteEmployee(int id) {
        db.DepartmentEmployees.RemoveRange(db.DepartmentEmployees.Where(y => y.EmployeeId == id)
            .ToArray());
        var employee = db.Employees.Remove(db.Employees.First(x => x.Id == id));
        db.SaveChanges();
        return employee;
    }
    
    public List<EmployeeDto> GetEmployeesForSkill(int id) {
        return db.EmployeeSkills
            .Where(x => x.SkillId == id)
            .Include(x => x.Employee)
            .ThenInclude(x => x.DepartmentEmployees)
            .ThenInclude(departmentEmployee => departmentEmployee.Department)
            .Select(x => new EmployeeDto {
                City = x.Employee.City,
                DepartmentId = x.Employee.DepartmentEmployees.First().DepartmentId,
                DepartmentName = x.Employee.DepartmentEmployees.First().Department.Name,
                Firstname = x.Employee.Firstname,
                Lastname = x.Employee.Lastname,
                Id = x.Employee.Id,
            })
            .ToList();
    }
}
namespace DepartmentsBackend.Services;

public interface IApiService {
    List<SkillDto> GetSkills();
    List<DepartmentDto> GetDepartments();
    DepartmentDto? GetDepartment(int id);
    List<DepartmentEmployeeDto> GetDepartmentEmployees(int id);
}

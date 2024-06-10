namespace DepartmentsBackend.Dtos;

public class DepartmentEmployeeDto {
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<string> SkillNames { get; set; }
}
namespace DepartmentsBackend.Dtos;

public class EmployeeDto {
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string City { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}
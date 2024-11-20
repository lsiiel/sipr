using SQLite;

namespace sisir.pages.employeeData;

[Table("employee_projects")]
public class EmployeeProject
{
    [PrimaryKey]
    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [PrimaryKey]
    [Column("project_id")]
    public int ProjectId { get; set; }
}

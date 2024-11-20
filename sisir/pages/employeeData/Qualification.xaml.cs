using SQLite;

namespace sisir.pages.employeeData;

[Table("qualifications")]
public class Qualification
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("qualification_id")]
    public int Id { get; set; }

    [Column("qualification_name")]
    public string LevelName { get; set; }

    [Column("salary_coefficient")]
    public decimal Coefficient { get; set; }
}

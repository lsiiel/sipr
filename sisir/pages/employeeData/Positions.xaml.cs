using SQLite;

namespace sisir.pages.employeeData;

[Table("positions")]
public class Position
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("position_id")]
    public int Id { get; set; }

    [Column("position_name")]
    public string Title { get; set; }

    [Column("salary")]
    public decimal Salary { get; set; }
}

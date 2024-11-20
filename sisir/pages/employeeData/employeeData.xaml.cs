using SQLite;
using System;
using System.Collections.Generic;

namespace sisir.pages.employeeData;

[Table("employees")]
public class EmployeeData
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("employee_id")]
    public int Id { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("middle_name")]
    public string MiddleName { get; set; }

    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }

    [Column("position_id")]
    public int PositionId { get; set; }

    [Column("qualification_id")]
    public int QualificationId { get; set; }

    [Column("telegram_nickname")]
    public string Telegram { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("passport_series")]
    public string PassportSeries { get; set; }

    [Column("passport_number")]
    public string PassportNumber { get; set; }

    [Column("passport_issued_by")]
    public string IssuedBy { get; set; }

    [Column("passport_issued_date")]
    public DateTime IssuedDate { get; set; }

    [Column("registration_address")]
    public string RegistrationAddress { get; set; }

    [Column("actual_address")]
    public string ResidentialAddress { get; set; }

    // Связь с должностью
    [Ignore]
    public Position Position { get; set; }

    // Связь с уровнем квалификации
    [Ignore]
    public Qualification Qualification { get; set; }

    // Связь с проектами
    [Ignore]
    public List<Project> Projects { get; set; } = new List<Project>();
}

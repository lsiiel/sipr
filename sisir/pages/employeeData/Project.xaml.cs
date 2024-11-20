using SQLite;
using System;

namespace sisir.pages.employeeData;

[Table("projects")]
    public class Project
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("project_id")]
        public int Id { get; set; }

        [Column("project_name")]
        public string ProjectName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("planned_start_date")]
        public DateTime PlannedStartDate { get; set; }

        [Column("planned_end_date")]
        public DateTime? PlannedEndDate { get; set; }

        [Column("actual_start_date")]
        public DateTime? ActualStartDate { get; set; }

        [Column("actual_end_date")]
        public DateTime? ActualEndDate { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("responsible_employee_id")]
        public int? ResponsibleEmployeeId { get; set; }

        [Column("team_id")]
        public int? TeamId { get; set; }
    }
using SQLite;
using System;

namespace sisir.pages.employeeData;

[Table("teams")]
    public class Team
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("team_id")]
        public int Id { get; set; }

        [Column("team_name")]
        public string TeamName { get; set; }
    }
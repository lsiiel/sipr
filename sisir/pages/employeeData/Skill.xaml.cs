using SQLite;
using System;

namespace sisir.pages.employeeData;

[Table("skills")]
    public class Skill
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("skill_id")]
        public int Id { get; set; }

        [Column("skill_name")]
        public string SkillName { get; set; }
    }
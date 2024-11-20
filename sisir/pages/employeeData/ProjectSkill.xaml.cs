using SQLite;
using System;

namespace sisir.pages.employeeData;
    
    [Table("project_skills")]
    public class ProjectSkill
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("skill_id")]
        public int SkillId { get; set; }
    }
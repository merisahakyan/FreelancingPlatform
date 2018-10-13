using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class UserSkill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public User User { get; set; }
        public Skill Skill { get; set; }
    }
}

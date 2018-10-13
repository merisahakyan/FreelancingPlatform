using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Skill
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public IEnumerable<UserSkill> UserSkills { get; set; }
    }
}

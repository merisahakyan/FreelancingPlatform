﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<UserSkill> UserSkills { get; set; }
    }
}

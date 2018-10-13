using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserSkillRepository : RepositoryBase<UserSkill>, IUserSkillRepository
    {
        public UserSkillRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

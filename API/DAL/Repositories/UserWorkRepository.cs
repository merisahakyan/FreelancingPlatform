using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserWorkRepository : RepositoryBase<UserWork>, IUserWorkRepository
    {
        public UserWorkRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

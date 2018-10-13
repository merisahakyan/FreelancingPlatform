using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EducationRepository : RepositoryBase<Education>, IEducationRepository
    {
        public EducationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

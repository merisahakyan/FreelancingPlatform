using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class WorkKeyRepository : RepositoryBase<WorkKey>, IWorkKeyRepository
    {
        public WorkKeyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

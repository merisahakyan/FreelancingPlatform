using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EploymentRepository : RepositoryBase<Employment>, IEmploymentRepository
    {
        public EploymentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

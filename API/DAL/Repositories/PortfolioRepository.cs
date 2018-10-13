using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class PortfolioRepository : RepositoryBase<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

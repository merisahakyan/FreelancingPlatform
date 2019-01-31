using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ProposalRepository : RepositoryBase<Proposal>, IProposalRepository
    {
        public ProposalRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

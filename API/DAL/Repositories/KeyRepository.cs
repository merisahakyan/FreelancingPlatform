using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class KeyRepository : RepositoryBase<Key>, IKeyRepository
    {
        public KeyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserCertificateRepository : RepositoryBase<UserCertificate>, IUserCertificateRepositiry
    {
        public UserCertificateRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CertificateRepository:RepositoryBase<Certificate>, ICertificateRepository
    {
        public CertificateRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Certificate : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<UserCertificate> UserCertificates { get; set; }

    }
}

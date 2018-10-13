using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserCertificate> UserCertificates { get; set; }

    }
}

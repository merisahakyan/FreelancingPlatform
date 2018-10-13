using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class UserCertificate : BaseEntity
    {
        public int UserId { get; set; }
        public int CertificateId { get; set; }
        public string URL { get; set; }
        public User User { get; set; }
        public Certificate Certificate { get; set; }
    }
}

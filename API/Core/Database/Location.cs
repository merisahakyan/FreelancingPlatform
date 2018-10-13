using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Location : BaseEntity
    {
        public string Country { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Employment> Companies { get; set; }
    }
}

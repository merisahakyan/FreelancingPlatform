using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}

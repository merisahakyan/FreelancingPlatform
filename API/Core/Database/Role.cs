using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}

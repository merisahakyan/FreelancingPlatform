using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Key : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<WorkKey> WorkKeys { get; set; }
    }
}

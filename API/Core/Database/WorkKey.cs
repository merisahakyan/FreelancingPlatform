using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class WorkKey : BaseEntity
    {
        public int? WorkId { get; set; }
        public int? KeyId { get; set; }
        public Key Key { get; set; }
        public Work Work { get; set; }
    }
}

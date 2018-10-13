using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class WorkKey
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public int KeyId { get; set; }
        public Key Key { get; set; }
        public Work Work { get; set; }
    }
}

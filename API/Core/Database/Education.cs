using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Education : BaseEntity
    {
        public string School { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

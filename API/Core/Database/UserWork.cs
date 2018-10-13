using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class UserWork : BaseEntity
    {
        public int UserId { get; set; }
        public int WorkId { get; set; }
        public decimal UserRate { get; set; }
        public decimal TotalEarned { get; set; }
        public User User { get; set; }
        public Work Work { get; set; }
    }
}

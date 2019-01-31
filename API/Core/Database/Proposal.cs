using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Proposal : BaseEntity
    {
        public double Rate { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public long DaysCount { get; set; }
        public int UserId { get; set; }
        public int WorkId { get; set; }
        public User User { get; set; }
        public Work Work { get; set; }
    }
}

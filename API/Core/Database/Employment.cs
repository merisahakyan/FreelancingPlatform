using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Employment : BaseEntity
    {
        public string Company { get; set; }
        public string City { get; set; }
        public string Title { get; set; }
        public string Role { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool CurrentlyWorking { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

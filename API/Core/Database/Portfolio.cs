using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Portfolio : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectUrl { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}

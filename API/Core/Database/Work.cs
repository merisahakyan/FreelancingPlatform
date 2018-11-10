using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Work : BaseEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public IEnumerable<WorkKey> WorkKeys { get; set; }
        public IEnumerable<UserWork> UserWorks { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}

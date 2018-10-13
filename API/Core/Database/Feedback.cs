using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }

        public int GivingId { get; set; }
        public User Giving { get; set; }
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.BusinessModels
{
    public class UserWorkModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public int WorkId { get; set; }
        public int UserId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal UserRate { get; set; }
        public decimal TotalEarned { get; set; }
        public FeedbackModel Feedback { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.BusinessModels
{
    public class ProposalModel
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public string Message { get; set; }
        public long DaysCount { get; set; }
        public int UserId { get; set; }
        public int WorkId { get; set; }
    }
}

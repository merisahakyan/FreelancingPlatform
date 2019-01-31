using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.ViewModels
{
    public class ProposalViewModel
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public UserViewModel User { get; set; }
        public int WorkId { get; set; }
    }
}

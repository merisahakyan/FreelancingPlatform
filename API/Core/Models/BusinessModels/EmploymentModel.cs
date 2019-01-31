using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.BusinessModels
{
    public class EmploymentModel
    {
        public string Role { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string  City { get; set; }
        public bool CurrentlyWorking { get; set; }
        public int LocationId { get; set; }
        public string Title { get; set; }
    }
}

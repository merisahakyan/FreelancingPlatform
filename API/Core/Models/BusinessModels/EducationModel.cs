using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.BusinessModels
{
    public class EducationModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Degree { get; set; }
        public string SchoolOrInstitute { get; set; }
        public string Description { get; set; }
    }
}

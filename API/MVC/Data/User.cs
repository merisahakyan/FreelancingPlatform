using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class User : IdentityUser<int>
    {
        public Roles Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DescriptionHeader { get; set; }
        public string Description { get; set; }
        public decimal HourlyRate { get; set; }
        public int TimePlusUTC { get; set; }
        public int HoursWorked { get; set; }
        public decimal TotalEarned { get; set; }
        public bool Availability { get; set; }
    }
}

using Core.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DescriptionHeader { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalEarned { get; set; }
        public LocationModel Location { get; set; }
    }
}

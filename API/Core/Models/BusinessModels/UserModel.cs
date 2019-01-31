using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.BusinessModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Phonenumber { get; set; }
        public string DescriptionHeader { get; set; }
        public string Description { get; set; }
        public decimal HourlyRate { get; set; }
        public int TimePlusUTC { get; set; }
        public int HoursWorked { get; set; }
        public decimal TotalEarned { get; set; }
        public int WorksCount { get; set; }
        public bool Availability { get; set; }
        public int RoleId { get; set; }
        public LocationModel Location { get; set; }
        public IEnumerable<UserWorkModel> WorkHistoryAndFeedback { get; set; }
        public IEnumerable<PortfolioModel> Portfolios { get; set; }
        public IEnumerable<SkillModel> Skills { get; set; }
        public IEnumerable<EmploymentModel> Employment { get; set; }
        public IEnumerable<EducationModel> Education { get; set; }
    }
}

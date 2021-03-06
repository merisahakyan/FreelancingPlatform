﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database
{
    public class User : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string DescriptionHeader { get; set; }
        public string Description { get; set; }
        public decimal HourlyRate { get; set; }
        public int TimePlusUTC { get; set; }
        public int? LocationId { get; set; }
        public int HoursWorked { get; set; }
        public decimal TotalEarned { get; set; }
        public bool Availability { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public Location Location { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Work> CreatedWorks { get; set; }
        public IEnumerable<UserWork> UserWorks { get; set; }
        public IEnumerable<Feedback> ReceivedFeedbacks { get; set; }
        public IEnumerable<Feedback> GivingFeedbacks { get; set; }
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public IEnumerable<Proposal> Proposals { get; set; }
        public IEnumerable<UserSkill> UserSkills { get; set; }
        public IEnumerable<UserCertificate> UserCertificates { get; set; }
        public ICollection<Employment> Employment { get; set; }
        public IEnumerable<Education> Educations { get; set; }
    }
}

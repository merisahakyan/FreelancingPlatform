using Core.Database;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models.FilterModels
{
    public class UserFilterModel : FilterBase<User>
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public decimal? HourlyRateStart { get; set; }
        public decimal? HourlyRateEnd { get; set; }
        public int? LocationId { get; set; }
        public int? HoursWorkedStart { get; set; }
        public int? HoursWorkedEnd { get; set; }
        public decimal? TotalEarnedStart { get; set; }
        public decimal? TotalEarnedEnd { get; set; }
        public bool? Availability { get; set; }
        public Roles? Role { get; set; }

        public override IQueryable<User> Filter(IQueryable<User> query)
        {
            if (Id.HasValue)
            {
                query = query.Where(u => u.Id == Id);
            }
            if (!string.IsNullOrEmpty(Firstname))
            {
                query = query.Where(u => u.Firstname.Contains(Firstname));
            }
            if (!string.IsNullOrEmpty(Lastname))
            {
                query = query.Where(u => u.Lastname.Contains(Lastname));
            }
            if (!string.IsNullOrEmpty(Username))
            {
                query = query.Where(u => u.Lastname.Contains(Username));
            }
            if (HourlyRateStart.HasValue)
            {
                query = query.Where(u => u.HourlyRate >= HourlyRateStart);
            }
            if (HourlyRateEnd.HasValue)
            {
                query = query.Where(u => u.HourlyRate <= HourlyRateEnd);
            }
            if (LocationId.HasValue)
            {
                query = query.Where(u => u.LocationId == LocationId);
            }
            if (HoursWorkedEnd.HasValue)
            {
                query = query.Where(u => u.HoursWorked <= HoursWorkedEnd);
            }
            if (HoursWorkedStart.HasValue)
            {
                query = query.Where(u => u.HoursWorked >= HoursWorkedStart);
            }
            if (TotalEarnedEnd.HasValue)
            {
                query = query.Where(u => u.TotalEarned <= TotalEarnedEnd);
            }
            if (TotalEarnedStart.HasValue)
            {
                query = query.Where(u => u.TotalEarned >= TotalEarnedStart);
            }
            if (Availability.HasValue)
            {
                query = query.Where(u => u.Availability == Availability);
            }
            if (Role.HasValue)
            {
                query = query.Where(u => u.RoleId == (int)Role);
            }
            return base.Filter(query);
        }
    }
}

using Core;
using Core.Database;
using Core.Models.BusinessModels;
using Core.Models.FilterModels;
using Core.Models.ViewModels;
using Core.OperationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class UserOperations : IUserOperations
    {
        IRepositoryManager _repositoryManager;
        public UserOperations(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void DeleteUser(int id)
        {
            _repositoryManager.Users.Delete(id);
            _repositoryManager.Users.SaveChanges();
        }

        public UserModel GetUser(int id)
        {
            var user = _repositoryManager.Users.GetSingleWithInclude(id, u => u.Location);
            var education = _repositoryManager.Educations.GetAll()
                                            .Where(e => e.UserId == id)
                                            .Select(e => new EducationModel
                                            {
                                                DateFrom = e.DateFrom,
                                                DateTo = e.DateTo,
                                                Description = $"{e.Description} | {e.School}",
                                                Degree = e.Degree,
                                            }).ToList();

            var employment = _repositoryManager.Employments.GetAll()
                                            .Where(e => e.UserId == id)
                                            .Select(e => new EmploymentModel
                                            {
                                                DateFrom = e.DateFrom,
                                                DateTo = e.DateTo,
                                                Description = e.Description,
                                                Company = e.Company,
                                                Role = e.Role
                                            }).ToList();

            var portfolios = _repositoryManager.Portfolios.GetAll()
                                              .Where(p => p.UserId == user.Id)
                                              .Select(p => new PortfolioModel
                                              {
                                                  Title = p.Title,
                                                  Description = p.Description
                                              }).ToList();

            var feedbacks = (from f in _repositoryManager.Feedbacks.GetAll()
                             join uw in _repositoryManager.UserWorks.GetAll()
                             on f.WorkId equals uw.WorkId
                             join w in _repositoryManager.Works.GetAll()
                             on uw.WorkId equals w.Id
                             where f.ReceiverId == user.Id && uw.UserId == user.Id

                             select new UserWorkModel
                             {
                                 Id = uw.Id,
                                 UserId = user.Id,
                                 Header = w.Header,
                                 DateFrom = uw.DateFrom,
                                 DateTo = uw.DateTo,
                                 TotalEarned = uw.TotalEarned,
                                 UserRate = uw.UserRate,
                                 WorkId = f.WorkId ?? 0,
                                 Feedback = new FeedbackModel
                                 {
                                     Rating = f.Rating,
                                     Message = f.Message,
                                 }
                             }).ToList();

            var skills = _repositoryManager.UserSkills.GetAll()
                                         .Where(s => s.UserId == user.Id)
                                         .Select(s => s.Skill)
                                         .Select(s => new SkillModel
                                         {
                                             Name = s.Name
                                         }).ToList();
            var userModel = new UserModel
            {
                Id = user.Id,
                Availability = user.Availability,
                Description = user.Description,
                DescriptionHeader = user.DescriptionHeader,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                HourlyRate = user.HourlyRate,
                HoursWorked = user.HoursWorked,
                TimePlusUTC = user.TimePlusUTC,
                TotalEarned = user.TotalEarned,
                WorksCount = user.UserWorks?.Count() ?? 0,
                Education = education,
                Employment = employment,
                Location = new LocationModel
                {
                    Id = user.Location.Id,
                    Country = user.Location.Country
                },
                Portfolios = portfolios,
                Skills = skills,
                WorkHistoryAndFeedback = feedbacks
            };

            return userModel;
        }

        public IEnumerable<UserViewModel> GetUsers(UserFilterModel filter)
        {
            var users = _repositoryManager.Users.GetAll();
            var locations = _repositoryManager.Locations.GetAll();
            users = filter.Filter(users);

            var usersList = from u in users
                            join l in locations on u.LocationId equals l.Id
                            select new UserViewModel
                            {
                                Id = u.Id,
                                DescriptionHeader = u.DescriptionHeader,
                                Firstname = u.Firstname,
                                Lastname = u.Lastname,
                                HourlyRate = u.HourlyRate,
                                TotalEarned = u.TotalEarned,
                                Location = new LocationModel
                                {
                                    Id = l.Id,
                                    Country = l.Country
                                }
                            };
            return usersList;
        }

        public UserViewModel RegisterUser(UserModel user)
        {
            var dbUser = new User()
            {
                Availability = user.Availability,
                Description = user.Description,
                DescriptionHeader = user.DescriptionHeader,
                Firstname = user.Firstname,
                HourlyRate = user.HourlyRate,
                Lastname = user.Lastname,
                LocationId = user.Location.Id,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.Phonenumber,
                TimePlusUTC = user.TimePlusUTC,
                RoleId = user.RoleId,
            };
            _repositoryManager.Users.Add(dbUser);
            _repositoryManager.Users.SaveChanges();

            if (user.Education != null)
                foreach (var e in user.Education)
                {
                    _repositoryManager.Educations.Add(new Education
                    {
                        DateFrom = e.DateFrom,
                        DateTo = e.DateTo,
                        Degree = e.Degree,
                        Description = e.Description,
                        School = e.SchoolOrInstitute,
                        UserId = dbUser.Id,
                    });
                }

            if (user.Employment != null)
                foreach (var e in user.Employment)
                {
                    _repositoryManager.Employments.Add(new Employment
                    {
                        DateFrom = e.DateFrom,
                        DateTo = e.DateTo,
                        Description = e.Description,
                        UserId = dbUser.Id,
                        City = e.City,
                        Company = e.Company,
                        CurrentlyWorking = e.CurrentlyWorking,
                        LocationId = e.LocationId,
                        Title = e.Title,
                        Role = e.Role
                    });
                }

            if (user.Portfolios != null)
                foreach (var e in user.Portfolios)
                {
                    _repositoryManager.Portfolios.Add(new Portfolio
                    {
                        Description = e.Description,
                        UserId = dbUser.Id,
                        ProjectUrl = e.ProjectUrl,
                        Title = e.Title,
                    });
                }

            if (user.Skills != null)
                foreach (var e in user.Skills)
                {
                    _repositoryManager.UserSkills.Add(new UserSkill
                    {
                        UserId = dbUser.Id,
                        SkillId = e.Id
                    });
                }

            _repositoryManager.Users.SaveChanges();

            return new UserViewModel
            {
                Id = dbUser.Id,
                DescriptionHeader = dbUser.DescriptionHeader,
                Firstname = dbUser.Firstname,
                HourlyRate = dbUser.HourlyRate,
                Lastname = dbUser.Lastname,
                TotalEarned = dbUser.TotalEarned
            };
        }

        public void UpdateUser(UserModel user)
        {
            var dbUser = new User()
            {
                Availability = user.Availability,
                Description = user.Description,
                DescriptionHeader = user.DescriptionHeader,
                Firstname = user.Firstname,
                HourlyRate = user.HourlyRate,
                Lastname = user.Lastname,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.Phonenumber,
                Username = user.Username,
            };
            _repositoryManager.Users.Update(dbUser);

            _repositoryManager.Users.SaveChanges();

        }
    }
}

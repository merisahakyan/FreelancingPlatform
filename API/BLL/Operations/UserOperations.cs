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
            var user = _repositoryManager.Users.GetSingle(id);
            var education = _repositoryManager.Educations.GetAll()
                                            .Where(e => e.UserId == id)
                                            .Select(e => new EducationModel
                                            {
                                                DateFrom = e.DateFrom,
                                                DateTo = e.DateTo,
                                                Description = $"{e.Description} | {e.School}",
                                                Degree = e.Degree,
                                            });

            var employment = _repositoryManager.Employments.GetAll()
                                            .Where(e => e.UserId == id)
                                            .Select(e => new EmploymentModel
                                            {
                                                DateFrom = e.DateFrom,
                                                DateTo = e.DateTo,
                                                Description = e.Description,
                                                Company = e.Company,
                                                Role = e.Role
                                            });
            var location = _repositoryManager.Locations.GetSingle(user.LocationId);

            var portfolios = _repositoryManager.Portfolios.GetAll()
                                              .Where(p => p.UserId == user.Id)
                                              .Select(p => new PortfolioModel
                                              {
                                                  Title = p.Title,
                                                  Description = p.Description
                                              });

            var feedbacks = from f in _repositoryManager.Feedbacks.GetAll()
                            where f.ReceiverId == user.Id
                            let userWork = _repositoryManager.UserWorks.GetAll()
                                                             .FirstOrDefault(u => u.UserId == user.Id && u.WorkId == f.WorkId)
                            let work = _repositoryManager.Works.GetSingle(f.WorkId)
                            select new UserWorkModel
                            {
                                UserId = user.Id,
                                Header = work.Header,
                                DateFrom = userWork.DateFrom,
                                DateTo = userWork.DateTo,
                                TotalEarned = userWork.TotalEarned,
                                UserRate = userWork.UserRate,
                                WorkId = f.WorkId,
                                Feedback = new FeedbackModel
                                {
                                    Rating = f.Rating,
                                    Message = f.Message,
                                }
                            };

            var skills = _repositoryManager.UserSkills.GetAll()
                                         .Where(s => s.UserId == user.Id)
                                         .Select(s => s.Skill)
                                         .Select(s => new SkillModel
                                         {
                                             Name = s.Name
                                         });
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
                WorksCount = user.UserWorks.Count(),
                Education = education,
                Employment = employment,
                Location = new LocationModel
                {
                    Id = location.Id,
                    Country = location.Country
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

            users = filter.Filter(users);

            var usersList = from u in users
                            let l = _repositoryManager.Locations.GetSingle(u.LocationId)
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
                });
            }

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

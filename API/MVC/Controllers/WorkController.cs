using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Enums;
using Core.Models.BusinessModels;
using Core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;

namespace MVC.Controllers
{
    public class WorkController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext("Server=(localdb)\\mssqllocaldb;Database=MvcApplicationDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        public IActionResult Freelancers()
        {
            List<UserViewModel> users = context.Users.Where(u => u.Role == Data.Roles.Freelancer).Select(u => new UserViewModel
            {
                Id = u.Id,
                DescriptionHeader = u.DescriptionHeader,
                Firstname = u.Firstname,
                HourlyRate = u.HourlyRate,
                Lastname = u.Lastname,
                TotalEarned = u.TotalEarned
            }).ToList();
            return View(users);
        }

        public IActionResult Jobs()
        {
            var jobViewModels = DataClass.jobs.Select(j => new WorkViewModel
            {
                Id = j.Id,
                Description = j.Description,
                Header = j.Header,
                WorkKeys = j.WorkKeys
            });
            return View(jobViewModels);
        }

        public IActionResult UserDetails(int id)
        {
            var dbUser = context.Users.FirstOrDefault(u => u.Id == id);
            var user = new UserModel
            {
                DescriptionHeader = dbUser.DescriptionHeader,
                Firstname = dbUser.Firstname,
                HourlyRate = dbUser.HourlyRate,
                Id = dbUser.Id,
                Lastname = dbUser.Lastname,
                TotalEarned = dbUser.TotalEarned,
                Availability = dbUser.Availability,
                Description = dbUser.Description,
                HoursWorked = dbUser.HoursWorked,
                TimePlusUTC = dbUser.TimePlusUTC,
                Username = dbUser.UserName,
                Phonenumber = dbUser.PhoneNumber,
                WorksCount = 0
            };
            return View(user);
        }

        public IActionResult JobDetails(int id)
        {
            var job = DataClass.jobs.FirstOrDefault(j => j.Id == id);
            return View(job);
        }

        public IActionResult ApplyHire(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyHire(ProposalModel model)
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var senderId = int.Parse(claim.Value);
            var sender = context.Users.FirstOrDefault(u => u.Id == senderId);
            if (sender.Role == Data.Roles.Freelancer)
            {
                string message = $"Hi, I want to apply to your job with rate {model.Rate} in {model.DaysCount} days. \r\n {model.Message} \r\n Best regards, {sender.Firstname} {sender.Lastname}";
                EmailSender.SendEmail(sender.Email, "www.merisahakyan@gmail.com", "merishok975", "Apply request", message);
            }
            else
            {
                string message = $"Hi, I want to hire you for my work with rate {model.Rate} in {model.DaysCount} days. \r\n {model.Message} \r\n Best regards, {sender.Firstname} {sender.Lastname}";
                EmailSender.SendEmail(sender.Email, "msahakyan1997@gmail.com", "merishok9799", "Hire request", message);
            }
            return View("../Home/Index");
        }

        public IActionResult CreateNewJob()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewJob(WorkModel model)
        {
            model.Id = DataClass.jobs.Max(j => j.Id) + 1;
            var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            model.CreatorId = int.Parse(claim.Value);
            DataClass.jobs.Add(model);
            return View("../Home/Index");
        }
    }
}
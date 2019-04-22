using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = new UserModel
            {
                DescriptionHeader = "Test",
                Firstname = "Firstname",
                HourlyRate = 10,
                Id = 1,
                Lastname = "Lastname",
                Location = new LocationModel
                {
                    Id = 1,
                    Country = "Armenia"
                },
                TotalEarned = 0,
                Availability = true,
                Description = "test",
                HoursWorked = 50,
                TimePlusUTC = 4,
                Username = "username",
                Phonenumber = "00000",
                WorksCount = 3
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
            DataClass.jobs.Add(model);
            return View("../Home/Index");
        }
    }
}
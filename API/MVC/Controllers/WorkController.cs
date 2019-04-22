using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.BusinessModels;
using Core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class WorkController : Controller
    {

        public IActionResult Freelancers()
        {
            List<UserViewModel> users = new List<UserViewModel>
            {
                new UserViewModel
                {
                    DescriptionHeader="Test",
                    Firstname="Firstname",
                    HourlyRate=10,
                    Id=1,
                    Lastname="Lastname",
                    Location=new LocationModel
                    {
                        Id=1,
                        Country="Armenia"
                    },
                    TotalEarned=0
                }
            };
            return View(users);
        }
        List<WorkViewModel> jobs = new List<WorkViewModel>
            {
                new WorkViewModel
                {
                    Description="Test",
                    Header="test",
                    WorkKeys=new List<string>(){"test"}
                }
            };
        public IActionResult Jobs()
        {

            return View(jobs);
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
            var job = new WorkModel
            {
                Description = "Test",
                Header = "test",
                WorkKeys = new List<string>() { "test" },
                Id = 1,
            };
            return View(job);
        }

        public IActionResult ApplyHire(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyHire(ProposalModel model)
        {
            return View("Jobs",jobs);
        }
    }
}
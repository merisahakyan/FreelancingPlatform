using Core.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public enum Roles
    {
        Freelancer, Other
    }

    public static class DataClass
    {
        public static List<WorkModel> jobs = new List<WorkModel>
            {
                new WorkModel
                {
                    Id =1,
                    Description="Test",
                    Header="test",
                    WorkKeys=new List<string>(){"test"},
                }
            };
    }
}

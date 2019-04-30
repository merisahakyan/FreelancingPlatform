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
                    Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Header="Need .Net developer",
                    WorkKeys=new List<string>(){".Net","Asp.Net Core","Entity Framework"},
                    CreatorId=2,
                },
                new WorkModel
                {
                    Id =2,
                    Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Header="Need JS.Net developer",
                    WorkKeys=new List<string>(){"JS","JQuery","HTML","CSS"},
                    CreatorId=2,
                }
            };
    }
}

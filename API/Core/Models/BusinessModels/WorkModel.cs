using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.BusinessModels
{
    public class WorkModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public List<string> WorkKeys { get; set; }
        public int CreatorId { get; set; }
        public UserModel Creator { get; set; }
        public List<FeedbackModel> Feedbacks { get; set; }
    }
}

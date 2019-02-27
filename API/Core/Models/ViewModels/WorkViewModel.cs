using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.ViewModels
{
    public class WorkViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public List<string> WorkKeys { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Data
{
    public class User : IdentityUser<int>
    {
        public Roles Role { get; set; }
    }
}

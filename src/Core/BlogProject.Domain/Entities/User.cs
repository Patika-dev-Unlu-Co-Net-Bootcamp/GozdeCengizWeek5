using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Memleket { get; set; }
        public bool Cinsiyet { get; set; }
    }
}
